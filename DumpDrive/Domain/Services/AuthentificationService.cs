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
                    //Console.WriteLine($"User {email} successfully logged in.");
                    return user;
                }
            }

            //Console.WriteLine("Invalid email or password.");
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
                //Console.WriteLine($"Logged in user: {_loggedInUser.Email}");
                return _loggedInUser;

            }
            else
            {
                //Console.WriteLine("No user is logged in.");
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
               // Console.WriteLine("User logged out.");
                Console.ReadLine();
                return true;
            }
            return false;
        }

    }
}
