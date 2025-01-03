using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum ChangeProfileResult
    {
        Success,
        UserNotLoggedIn,
        InvalidCurrentPassword,
        PasswordsDoNotMatch,
        WeakPassword,
        InvalidEmail,
        EmailAlreadyExists
    }


}
