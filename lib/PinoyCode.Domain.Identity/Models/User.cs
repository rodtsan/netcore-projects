using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace PinoyCode.Domain.Identity.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }
}