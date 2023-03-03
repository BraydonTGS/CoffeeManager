using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyCoffeeApp.Domain.DTO
{
    public class CoffeeDto
    {
        public Guid CoffeeId { get; set; }

        public string CoffeeRoaster { get; set; } = string.Empty;

        public string CoffeeName { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

        public Guid UserId { get; set; }

        public UserDto User { get; set; }
    }
}
