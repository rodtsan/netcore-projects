using PinoyCode.Data.Infrustracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinoyCode.Data.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.Commit();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.CommitAsync();
        }
    }
}
