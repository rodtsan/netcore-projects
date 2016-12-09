using PinoyCode.Data.Infrustracture;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace PinoyCode.Data
{
    //public delegate void ModelCreatingHandler(ModelBuilder builder);
    //public class PCDbContext : DbContextBase<DbContext>, IDbContext
    //{
    //    public event ModelCreatingHandler OnModelCreated;
    //    public PCDbContext(DbContextOptions<DbContext> options)
    //        : base(options)
    //    {

    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {

    //        base.OnConfiguring(optionsBuilder);
    //    }

    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        this.OnModelCreated?.Invoke(builder);

    //        base.OnModelCreating(builder);
    //        // Customize the ASP.NET Identity model and override the defaults if needed.
    //        // For example, you can rename the ASP.NET Identity table names and more.
    //        // Add your customizations after calling base.OnModelCreating(builder);
    //    }

    //}

    public delegate void ModelCreatingHandler(ModelBuilder builder);
    public class DbContextBase : DbContext, IDbContext
    {
        public event ModelCreatingHandler OnModelCreated;
        public DbSet<Profile> Profiles { get; set; }

        public DbContextBase(DbContextOptions<DbContextBase> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.OnModelCreated?.Invoke(modelBuilder);

            modelBuilder.Entity<Profile>(t =>
            {
                t.Property(p => p.Id).ValueGeneratedOnAdd();
                t.Property(p => p.Name);
                t.Property(p => p.RegisteredOn);
                t.HasKey(p => p.Id);
                t.ToTable("Profiles");
            });

            base.OnModelCreating(modelBuilder);

           
        }

        public int Commit()
        {
            return this.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await this.SaveChangesAsync();
        }

        public DbSet<T> Table<T>() where T : class
        {
            return this.Set<T>();
        }
    }
}
