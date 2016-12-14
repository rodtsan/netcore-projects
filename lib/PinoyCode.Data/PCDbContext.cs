using Microsoft.EntityFrameworkCore;
using PinoyCode.Data.Infrustracture;
using System.Threading.Tasks;
using System;

namespace PinoyCode.Data
{
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

        public T GetService<T>()
        {
            throw new NotImplementedException();
        }
    }
}
