using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseModel> RegisterAsync(RegistrationModel registrationModel)
        {
            var age = DateTime.Today.Year - registrationModel.BirthDate.Year;
            if (age < 20)
                return new ResponseModel {isCreated = false, Message = "Age must be at least 20" };
            if (!IsValidEmail(registrationModel.Email))
                return new ResponseModel { isCreated = false, Message = "Please Enter a valid Email" };
            var emailExists = await _context.Users.AnyAsync(u => u.Email == registrationModel.Email);
            if (emailExists)
            {
                return new ResponseModel
                {
                    isCreated = false,
                    Message = "An account with this email already exists."
                };
            }
            if (!IsValidMobileNumber(registrationModel.PhoneNumber))
                return new ResponseModel { isCreated = false, Message = "Please Enter a valid Mobile Number" };

            var validGovernorates = await _context.Governorates.Select(g => g.Name).ToListAsync();
            foreach (var address in registrationModel.Addresses)
            {
                // Validate the governorate name
                if (!validGovernorates.Contains(address.Governate))
                {
                    return new ResponseModel
                    {
                        isCreated = false,
                        Message = $"Governorate '{address.Governate}' is not valid."
                    };
                }

                // Fetch valid cities for this governorate
                var validCities = await _context.Cities
                    .Where(c => c.Governorate.Name == address.Governate)
                    .Select(c => c.Name)
                    .ToListAsync();

                // Validate the city name
                if (!validCities.Contains(address.City))
                {
                    return new ResponseModel
                    {
                        isCreated = false,
                        Message = $"City '{address.City}' is not valid for the governorate '{address.Governate}'."
                    };
                }
            }

            var registeredUser = _mapper.Map<User>(registrationModel);

            await _context.Users.AddAsync(registeredUser);
            await _context.SaveChangesAsync();
            
            var responseModel = _mapper.Map<ResponseModel>(registeredUser);
            responseModel.isCreated = true;
            responseModel.Message = "User has been registered Successfully";
            return responseModel;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _context.Users.Include(u => u.Addresses).ToListAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
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
