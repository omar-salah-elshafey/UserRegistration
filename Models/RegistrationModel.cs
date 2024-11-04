using System.ComponentModel.DataAnnotations;
using UserRegistration.Data;

namespace UserRegistration.Models
{
    public class RegistrationModel
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(40)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public List<AddressDto> Addresses { get; set; }
    }
}
