namespace SMT.BlazorApp.Data
{
    public class UserDto : BaseDto
    {
        public string EmployeeId { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }

        public string Status { get; set; } = string.Empty;

        public string StatusType { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string Suffix { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public List<string> FSOs { get; set; } = new();

        public List<string> AFSOs { get; set; } = new();

        public List<string> ISSMs { get; set; } = new();

        public string AccessToken { get; set; } = string.Empty;
    }
}