using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PinoyCode.Data.Extensions
{
    public static class DbEntityExtensions
    {
        public static void AddOrUpdate<T>(this DbSet<T> db, T entity) where T : class
        {
            var entry = db.Attach(entity);
            switch (entry.State)
            {
                case EntityState.Detached:
                    db.Add(entity);
                    break;
                case EntityState.Modified:
                    db.Update(entity);
                    break;
                case EntityState.Added:
                    db.Add(entity);
                    break;
                case EntityState.Unchanged:
                   // db.Update(entity);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static async Task AddOrUpdateAsync<T>(this DbSet<T> db, T entity) where T : class
        {
            var entry = db.Attach(entity);
            switch (entry.State)
            {
                case EntityState.Detached:
                    await db.AddAsync(entity);
                    break;
                case EntityState.Modified:
                    db.Update(entity);
                    break;
                case EntityState.Added:
                    await db.AddAsync(entity);
                    break;
                case EntityState.Unchanged:
                    //item already in db no need to do anything
                   // db.Update(entity);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }

}
