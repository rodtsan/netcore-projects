using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PinoyCode.Domain.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PinoyCode.Domain.Identity
{
    public sealed class ApplicationIdentityDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-PinoyCode.Web-2fbb4adb-c3ce-4ce5-bca3-575e4c4e0f94;Trusted_Connection=True;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
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
