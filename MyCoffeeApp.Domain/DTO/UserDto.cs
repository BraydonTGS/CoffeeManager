﻿namespace MyCoffeeApp.Domain.DTO
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public IEnumerable<CoffeeDto> Coffees { get; set; } = Enumerable.Empty<CoffeeDto>();
    }
}