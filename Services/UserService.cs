using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using UserRegistration.Data;
using UserRegistration.Models;

namespace UserRegistration.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> RegisterAsync(RegistrationModel registrationModel)
        {
            var registeredUser = new User();
            var age = DateTime.Today.Year - registrationModel.BirthDate.Year;
            if (age < 20)
                return new ResponseModel {isCreated = false, Message = "Age must be at least 20" };
            if (!IsValidEmail(registrationModel.Email))
                return new ResponseModel { isCreated = false, Message = "Please Enter a valid Email" };
            if (!IsValidMobileNumber(registrationModel.PhoneNumber))
                return new ResponseModel { isCreated = false, Message = "Please Enter a valid Mobile Number" };
            registeredUser.FirstName = registrationModel.FirstName;
            registeredUser.MiddleName = registrationModel.MiddleName;
            registeredUser.LastName = registrationModel.LastName;
            registeredUser.Email = registrationModel.Email;
            registeredUser.PhoneNumber = registrationModel.PhoneNumber;
            registeredUser.BirthDate = registrationModel.BirthDate;
            registeredUser.Password = registrationModel.Password;
            registeredUser.Addresses = registrationModel.Addresses.Select(a => new Address
            {
                Governate = a.Governate,
                City = a.City,
                Street = a.Street,
                BuildingNumber = a.BuildingNumber,
                FlatNumber = a.FlatNumber
            }).ToList();
            await _context.Users.AddAsync(registeredUser);
            await _context.SaveChangesAsync();
            return new ResponseModel
            {
                Id = registeredUser.Id,
                FirstName = registeredUser.FirstName,
                MiddleName = registeredUser.MiddleName,
                LastName = registeredUser.LastName,
                Email = registeredUser.Email,
                PhoneNumber = registeredUser.PhoneNumber,
                BirthDate = registeredUser.BirthDate,
                Addresses = registeredUser.Addresses.Select(a => new AddressDto
                {
                    Governate = a.Governate,
                    City = a.City,
                    Street = a.Street,
                    BuildingNumber = a.BuildingNumber,
                    FlatNumber = a.FlatNumber
                }).ToList(),
                isCreated = true,
                Message = "User has been registered Successfully"
            };
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _context.Users.Include(u => u.Addresses).ToListAsync();
            var userDto = new List<UserDto>();
            foreach (var user in users)
            {
                userDto.Add(new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    BirthDate = user.BirthDate,
                    Addresses = user.Addresses.Select(a => new AddressDto
                    {
                        Governate = a.Governate,
                        City = a.City,
                        Street = a.Street,
                        BuildingNumber = a.BuildingNumber,
                        FlatNumber = a.FlatNumber
                    }).ToList()
                });
            }
            return userDto;
        }

        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[A-Za-z0-9.-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidMobileNumber(string mobileNumber)
        {
            var mobilePattern = @"^(?:\+2)?(010|011|012|015)\d{8}$";
            return Regex.IsMatch(mobileNumber, mobilePattern);
        }
    }
}
