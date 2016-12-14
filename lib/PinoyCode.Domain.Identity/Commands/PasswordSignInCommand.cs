using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Identity.Commands
{
    public class PasswordSignInCommand
    {
        public Guid Id;
        public string Email;
        public string Password;
        public bool RememberMe;
        public string Message;
        public bool HasError;
        public bool Succeeded;
        public bool RequiresTwoFactor;
        public bool IsLockedOut;
        public bool IsNotAllowed;
    }
}
