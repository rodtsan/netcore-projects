using PinoyCode.Domain.Identity.Models;
using System;

namespace PinoyCode.Domain.Identity.Commands
{
    public class UserSignInCommand 
    {
        public Guid Id;
        public string Message;
        public bool SignedIn;
    }
}
