using Data.Entities.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;
namespace Domain.Services
{
    public class UserSettingsService
    {
        private readonly UserRepository _userRepository;
        public UserSettingsService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ChangeProfileResult ChangePassword(User user, string currentPassword, string newPassword, string confirmPassword)
        {
            if (user == null)
                return ChangeProfileResult.UserNotLoggedIn;
            if (user.Password != currentPassword)
                return ChangeProfileResult.InvalidCurrentPassword;
            if (newPassword != confirmPassword)
                return ChangeProfileResult.PasswordsDoNotMatch;
            if (newPassword.Length < 8 || !newPassword.Any(char.IsDigit) || !newPassword.Any(char.IsLetter))
                return ChangeProfileResult.WeakPassword;
            user.Password = newPassword;
            _userRepository.Update(user);
            return ChangeProfileResult.Success;
        }
        public ChangeProfileResult ChangeEmail(User user, string newEmail)
        {
            if (user == null)
                return ChangeProfileResult.UserNotLoggedIn;
            if (!newEmail.Contains("@"))
                return ChangeProfileResult.InvalidEmail;
            if (_userRepository.Exists(newEmail))
                return ChangeProfileResult.EmailAlreadyExists;
            user.Email = newEmail;
            _userRepository.Update(user);
            return ChangeProfileResult.Success;
        }
        public bool ValidateCurrentPassword(User user, string currentPassword)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return user.Password == currentPassword;

        }
        public bool ValidateCurrentEmail(User user, string currentEmail)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return string.Equals(user.Email, currentEmail, StringComparison.OrdinalIgnoreCase);
        }

    }
}
