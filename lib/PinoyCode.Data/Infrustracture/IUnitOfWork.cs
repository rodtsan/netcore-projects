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
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits this instance.
        /// </summary>
        int Commit();
        Task<int> CommitAsync();
    }
}
