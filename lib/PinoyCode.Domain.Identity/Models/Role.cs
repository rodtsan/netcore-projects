using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace PinoyCode.Domain.Identity.Models
{
    public class Role : IdentityRole<Guid>
    {

        public Role()
        {
            Id = Guid.NewGuid();
        }
    }
}
