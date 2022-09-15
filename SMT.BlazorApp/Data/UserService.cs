using IdentityModel.Client;
using Microsoft.Identity.Web;
using Newtonsoft.Json;

namespace SMT.BlazorApp.Data
{
    public class UserService
    {
        private HttpClient _client;
        private readonly IHttpClientFactory _factory;
        private readonly ITokenAcquisition _tokenAcquisition;

        public UserService(IHttpClientFactory factory, ITokenAcquisition tokenAcquisition)
        {
            _client = factory.CreateClient("smt-client");
            _factory = factory;
            _tokenAcquisition = tokenAcquisition;
        }

        public async Task<UserDto[]> GetUsers()
        {
            var token = await _tokenAcquisition.GetAuthenticationResultForUserAsync(new string[] { "api://ad85b099-47ef-4f91-b9f7-c5bc529b4e2e/SMTService" });
            _client.SetBearerToken(token.AccessToken);
            var response = await _client.GetAsync("user/get");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto[]>(content);
        }

        public async Task<string> Login()
        {
            //api://c4d140c8-d2dc-44e8-938d-34f408fec42a/SMTService
            //pumex: api://ad85b099-47ef-4f91-b9f7-c5bc529b4e2e/SMTService
            var token = await _tokenAcquisition.GetAuthenticationResultForUserAsync(new string[] { "api://ad85b099-47ef-4f91-b9f7-c5bc529b4e2e/SMTService" });
            _client.SetBearerToken(token.AccessToken);
            var response = await _client.GetAsync($"user/access");
            var content = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<ResponseResult<UserDto>>(content);

            var newClient = new HttpClient() { BaseAddress = new Uri("http://localhost:7071/api/") };
            //var newClient = new HttpClient() { BaseAddress = new Uri("https://serco-smt-service.azurewebsites.net/api/") };
            newClient.SetBearerToken(model.Model.AccessToken);
            var xRespone = await newClient.GetAsync("dashboard/get");
            var xContent = await xRespone.Content.ReadAsStringAsync();
            return content;
        }
    }
}