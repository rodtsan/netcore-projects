using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PinoyCode.Domain.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PinoyCode.Domain.Identity
{
    public sealed class IdentityDbContext : IdentityDbContext<User, Role, Guid>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            foreach (var model in builder.Model.GetEntityTypes()
           .Where(p => p.Relational().TableName.StartsWith(@"AspNet")))
                    {
                        string tableName = model.Relational().TableName.Remove(0, @"AspNet".Length);
                        model.Relational().TableName = tableName;
                    }
        }
    }
}
