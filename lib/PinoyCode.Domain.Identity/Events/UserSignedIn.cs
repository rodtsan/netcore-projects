using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Identity.Events
{
    public class UserSignedIn 
    {
        public Guid Id;
        public string UserName;
        public string Message;
        public bool SignedIn;
    }
}
