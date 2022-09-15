using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using SMT.BlazorApp;
using SMT.BlazorApp.Areas.Identity;
using SMT.BlazorApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
    .EnableTokenAcquisitionToCallDownstreamApi(new string[] { "api://ad85b099-47ef-4f91-b9f7-c5bc529b4e2e/SMTService" })
    .AddInMemoryTokenCaches();

//api://c4d140c8-d2dc-44e8-938d-34f408fec42a/SMTService

builder.Services.Configure<OpenIdConnectOptions>(options =>
{
    options.SaveTokens = true;
});

builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddScoped<TokenProvider>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();

builder.Services.AddHttpClient("smt-client", client =>
{
    client.BaseAddress = new Uri("http://localhost:7071/api/");
    //client.BaseAddress = new Uri("https://serco-smt-service.azurewebsites.net/api/");
});

builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
