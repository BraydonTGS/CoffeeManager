using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyCoffeeApp.Domain.DTO
{
    public class CoffeeRequest
    {
        public Guid CoffeeId { get; set; }
        public string CoffeeRoaster { get; set; } = string.Empty;

        public string CoffeeName { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

    }
}
