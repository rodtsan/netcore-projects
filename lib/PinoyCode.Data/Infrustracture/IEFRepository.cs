using System;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Data.Infrustracture
{
    public interface IEFRepository<T> : IEFRepository, IDisposable  where T : class, new()
    {
        IQueryable<T> TableTracking { get; }
        IQueryable<T> TableNoTracking { get; }
        void Add(T entity);
        Task AddAsync(T entity);
        void Delete(T entity);
        T GetById(object Id);
        Task<T> GetByIdAsync(object Id);
        void Update(T entity);
    }

    public interface IEFRepository
    {

    }
}