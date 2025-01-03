using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services;
using Data.Enums;
namespace Presentation
{
    public class ProfileSettingsMenu
    {
        private readonly UserSettingsService _userSettingsService;
        private readonly User _user;
        public ProfileSettingsMenu(UserSettingsService userSettingsService, User user)
        {
            _userSettingsService = userSettingsService;
            _user = user;
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("1. Change password");
            Console.WriteLine("2. Change email");
            Console.WriteLine("3. Back to main menu");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ChangePassword();
                    break;
                case "2":
                    ChangeEmail();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Show();
                    break;
            }
        }
        private void ChangePassword()
        {
            Console.Write("Enter current password: ");
            var currentPassword = Console.ReadLine();
            var isCurrentPasswordValid = _userSettingsService.ValidateCurrentPassword(_user, currentPassword);
            if (!isCurrentPasswordValid)
            {
                Console.WriteLine("Current password is incorrect. Password change aborted.");
                Console.WriteLine("\nPress any key to return.");
                Console.ReadKey();
                Show();
                return;
            }
            Console.Write("Enter new password: ");
            var newPassword = Console.ReadLine();
            Console.Write("Confirm new password: ");
            var confirmPassword = Console.ReadLine();
            var result = _userSettingsService.ChangePassword(_user, currentPassword, newPassword, confirmPassword);
            switch (result)
            {
                case ChangeProfileResult.Success:
                    Console.WriteLine("Password successfully changed!");
                    break;
                case ChangeProfileResult.UserNotLoggedIn:
                    Console.WriteLine("You must be logged in to perform this action.");
                    break;
                case ChangeProfileResult.InvalidCurrentPassword:
                    Console.WriteLine("Current password is incorrect.");
                    break;
                case ChangeProfileResult.PasswordsDoNotMatch:
                    Console.WriteLine("New passwords do not match.");
                    break;
                case ChangeProfileResult.WeakPassword:
                    Console.WriteLine("New password is not strong enough.");
                    break;
            }
            Console.WriteLine("\nPress any key to return.");
            Console.ReadKey();
            Show();
        }
        private void ChangeEmail()
        {
            Console.Write("Enter your current email address: ");
            var currentEmail = Console.ReadLine();

            // Provera trenutnog email-a
            var isCurrentEmailValid = _userSettingsService.ValidateCurrentEmail(_user, currentEmail);
            if (!isCurrentEmailValid)
            {
                Console.WriteLine("Current email is incorrect. Email change aborted.");
                Console.WriteLine("\nPress any key to return.");
                Console.ReadKey();
                Show();
                return;
            }
            Console.Write("Enter new email address: ");
            var newEmail = Console.ReadLine();
            var result = _userSettingsService.ChangeEmail(_user, newEmail);
            switch (result)
            {
                case ChangeProfileResult.Success:
                    Console.WriteLine("Email successfully changed!");
                    break;
                case ChangeProfileResult.UserNotLoggedIn:
                    Console.WriteLine("You must be logged in to perform this action.");
                    break;
                case ChangeProfileResult.InvalidEmail:
                    Console.WriteLine("The email address provided is not valid.");
                    break;
                case ChangeProfileResult.EmailAlreadyExists:
                    Console.WriteLine("The email address is already in use.");
                    break;
            }
            Console.WriteLine("\nPress any key to return.");
            Console.ReadKey();
            Show();
        }
    }
}
