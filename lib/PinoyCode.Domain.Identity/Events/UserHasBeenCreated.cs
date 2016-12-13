using Microsoft.AspNetCore.Identity;
using PinoyCode.Domain.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Identity.Events
{
    public class UserHasBeenCreated
    {
        public Guid Id;
        public User User;
        public bool Succeeded;
        
    }
}
