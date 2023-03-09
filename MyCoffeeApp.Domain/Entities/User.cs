using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCoffeeApp.Domain.Entities
{
    [Table("UserInfo")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(25, ErrorMessage = "Exceeded 25 character maxium.")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50, ErrorMessage = "Exceeded 50 character maxium.")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(150, ErrorMessage = "Exceeded 100 character maxium.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
        public IEnumerable<Coffee> Coffees { get; set; } = Enumerable.Empty<Coffee>();
    }
}
