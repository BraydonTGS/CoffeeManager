using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCoffeeApp.Domain.Entities
{
    [Table("Coffee")]
    public class Coffee
    {
        [Key]
        public Guid CoffeeId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Exceeded 50 character maxium")]
        public string CoffeeRoaster { get; set; } = string.Empty;

        [Required]
        [MaxLength(50, ErrorMessage = "Exceeded 50 character maxium.")]
        public string CoffeeName { get; set; } = string.Empty;

        [Required]
        [MaxLength(250, ErrorMessage = "Exceeded 50 character maxium.")]
        public string ImagePath { get; set; } = string.Empty;

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
