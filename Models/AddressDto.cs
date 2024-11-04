using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Models
{
    public class AddressDto
    {
        [Required]
        public string Governate { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MaxLength(200)]
        public string Street { get; set; }
        [Required]
        public string BuildingNumber { get; set; }
        [Required]
        public int FlatNumber { get; set; }
    }
}
