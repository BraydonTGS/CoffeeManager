using System.Text.Json.Serialization;

namespace MyCoffeeApp.Domain.DTO
{
    public class UserRequest
    {
        // DB Guid 53D4FA69-970B-4963-A409-51E1F552BAE4
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}