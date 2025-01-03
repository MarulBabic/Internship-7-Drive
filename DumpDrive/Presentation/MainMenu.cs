using System;
using Data.Entities.Models;
using Domain.Services;
using Microsoft.AspNetCore.Identity;
namespace Presentation
{
    public class MainMenu
    {
        private readonly AuthenticationService _authService;
        private UserMenu _userMenu;

        public MainMenu(AuthenticationService authService)
        {
            _authService = authService;
        }
        public void SetUserMenu(UserMenu userMenu)
        {
            _userMenu = userMenu;
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Welcome to DUMP Drive!");

            var loggedInUser = _authService.GetLoggedInUser();
            if (loggedInUser != null)
            {
                Console.WriteLine("You are already logged in.");
                var userMenu = new UserMenu(_authService, this);
                userMenu.ShowUserMenu();
            }
            else
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");

                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        Console.WriteLine("Thank you for using the application!");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Try again!");
                        Show();
                        break;
                }
            }
        }


        private void Login()
        {
            Console.Clear();
            Console.WriteLine("=== Login ===");
            int attemptCount = 0;
            DateTime lastAttemptTime = DateTime.MinValue;
            while (attemptCount < 3)
            {
                if ((DateTime.Now - lastAttemptTime).TotalSeconds < 30 && attemptCount > 0)
                {
                    Console.WriteLine("Please wait 30 seconds before trying again.");
                    System.Threading.Thread.Sleep(30000);
                }
                Console.Write("Email: ");
                var email = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine()?.Trim();
                var user = _authService.Login(email, password);
                if (user != null)
                {
                    Console.WriteLine("You have successfully logged in!");
                    if (_userMenu == null)
                    {
                        _userMenu = new UserMenu(_authService, this);
                    }
                    _userMenu.ShowUserMenu();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid email or password combination.");
                    attemptCount++;
                    lastAttemptTime = DateTime.Now;
                    if (attemptCount >= 3)
                    {
                        Console.WriteLine("You have exceeded the maximum number of attempts. Please wait 30 seconds.");
                        System.Threading.Thread.Sleep(30000);
                        attemptCount = 0;
                    }
                    else
                    {
                        Console.WriteLine("Please wait 30 seconds before trying again.");
                        System.Threading.Thread.Sleep(30000);
                    }
                }
            }
        }
        private void Register()
        {
            Console.Clear();
            Console.WriteLine("=== Registration ===");
            string email;
            while (true)
            {
                Console.Write("Email: ");
                email = Console.ReadLine();

                if (_authService.ValidateEmail(email))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid email format. Please enter a valid email.");
                }
            }

            Console.Write("Password: ");
            var password = Console.ReadLine();
            Console.Write("Confirm Password: ");
            var confirmPassword = Console.ReadLine();
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();
            string captcha = GenerateCaptcha();
            for (int attempts = 0; attempts < 3; attempts++)
            {
                Console.WriteLine($"Please enter the CAPTCHA to confirm you are not a bot: {captcha}");
                string captchaInput = Console.ReadLine();

                if (captchaInput == captcha)
                {
                    Console.WriteLine("CAPTCHA validation successful!");
                    break;
                }

                if (attempts == 2)
                {
                    Console.WriteLine("CAPTCHA validation failed. Registration cancelled.");
                }

                Console.WriteLine("Incorrect CAPTCHA. Please try again.");
            }
            if (_authService.Register(email, password, confirmPassword, firstName, lastName))
            {
                Console.WriteLine("Registration successful!");
                var user = _authService.Login(email, password);
                if (user != null)
                {
                    if (_userMenu == null)
                    {
                        _userMenu = new UserMenu(_authService, this);
                    }
                    _userMenu.ShowUserMenu();
                }
                else
                {
                    Show();
                }
            }
            else
            {
                Console.WriteLine("Error during registration.");
                Show();
            }
        }
        private string GenerateCaptcha()
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
