using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PinoyCode.Data.Infrustracture
{
    public interface IDbContext
    {
        DbSet<T> Table<T>() where T : class;
        int Commit();
        Task<int> CommitAsync();
      
        
    }
}
