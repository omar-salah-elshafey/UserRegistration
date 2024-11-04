using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Data
{
    public class Address
    {
        public int Id { get; set; }
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
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
