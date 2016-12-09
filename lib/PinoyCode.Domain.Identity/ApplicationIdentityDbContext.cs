using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PinoyCode.Domain.Identity.Models;
using System;
using System.Linq;

namespace PinoyCode.Domain.Identity
{
    public class ApplicationIdentityDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
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
