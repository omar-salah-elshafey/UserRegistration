﻿using System.ComponentModel.DataAnnotations;
using UserRegistration.Data;

namespace UserRegistration.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<AddressDto> Addresses { get; set; }

    }
}