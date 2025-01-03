using Data.Entities.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Domain.Services
{
    public class AuthenticationService
    {
        private readonly UserRepository _userRepository;
        private User? _loggedInUser;
        public AuthenticationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserRepository GetUserRepository()
        {
            return _userRepository;
        }
        public User? Login(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);
            if (user != null)
            {
                var passwordHasher = new PasswordHasher<User>();
                var verificationResult = passwordHasher.VerifyHashedPassword(user, user.Password, password);

                if (verificationResult == PasswordVerificationResult.Success)
                {
                    _loggedInUser = user;
                    return user;
                }
            }

            return null;
        }



        public bool Register(string email, string password, string confirmPassword, string firstName, string lastName)
        {
            if (!ValidateEmail(email))
            {
                return false;
            }
            if (password != confirmPassword)
                return false;

            if (_userRepository.Exists(email))
                return false;
            var passwordHasher = new PasswordHasher<User>();

            var newUser = new User { Email = email, FirstName = firstName, LastName = lastName, CreatedAt = DateTime.UtcNow };
            newUser.Password = passwordHasher.HashPassword(newUser, password);

            _userRepository.Add(newUser);
            return true;
        }


        public User? GetLoggedInUser()
        {
            
            if (_loggedInUser != null)
            {
                return _loggedInUser;

            }
            else
            {
                return null;
            }
        }


        public bool ValidateEmail(string email)
        {
            string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]{3,}$";
            return Regex.IsMatch(email, emailPattern);
        }
        public bool Logout()
        {
            if (_loggedInUser != null)
            {
                _loggedInUser = null;
                return true;
            }
            return false;
        }

        public string GenerateCaptcha()
        {
            var random = new Random();
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            string captcha = "";
            captcha += letters[random.Next(letters.Length)];
            captcha += digits[random.Next(digits.Length)];
            captcha += (random.Next(2) == 0) ? letters[random.Next(letters.Length)] : digits[random.Next(digits.Length)];
            captcha += (random.Next(2) == 0) ? letters[random.Next(letters.Length)] : digits[random.Next(digits.Length)];
            captcha = new string(captcha.OrderBy(c => random.Next()).ToArray());
            return captcha;
        }

    }
}
