using System;

namespace PinoyCode.Domain.Identity.Commands
{
    public class CreateUserCommand 
    {
        public Guid Id;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;
        public string UserName;
        public string Message;
        public bool Succeeded;
    
    }
}
