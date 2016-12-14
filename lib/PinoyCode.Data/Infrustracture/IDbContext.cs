using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace PinoyCode.Data.Infrustracture
{
    public interface IDbContext : IDisposable
    {
        DbSet<T> Table<T>() where T : class;
        int Commit();
        Task<int> CommitAsync();
        T GetService<T>();
       
    }
}
