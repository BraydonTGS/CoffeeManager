using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MyCoffeeApp.DataAccess.Entities
{
    [Table("UserInfo")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [MaxLength(25, ErrorMessage = "Exceeded 25 character maxium.")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Exceeded 50 character maxium.")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Exceeded 100 character maxium.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IEnumerable<Coffee> Coffees { get; set; } = Enumerable.Empty<Coffee>();
}
