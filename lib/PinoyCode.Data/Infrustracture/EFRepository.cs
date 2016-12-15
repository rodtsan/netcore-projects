using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Data.Infrustracture
{

    public class EFRepository<T> : IEFRepository<T> where T : class, new()
    {
        private readonly IDbContext _dbContext;
        public EFRepository(IDbContext content)
        {
            this._dbContext = content;
        }

        public T GetById(object Id)
        {
            return this.Table.Find(Id);
        }

        public async Task<T> GetByIdAsync(object Id)
        {
            return await this.Table.FindAsync(Id);
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Table.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            await this.Table.AddAsync(entity);
        }

        public void Update(T entity)
        {
            this.Table.Update(entity);
        }


        public void Delete(T entity)
        {
            this.Table.Remove(entity);
        }

        public IQueryable<T> TableTracking
        {
            get
            {
                return this.Table.AsTracking();
            }
        }

        public IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Table.AsNoTracking();
            }
        }

        private DbSet<T> Table
        {
            get
            {
                return this._dbContext.Table<T>();
            }
        }

        private int Commit()
        {
            try
            {
                return this._dbContext.Commit();
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception("Database Concurrency error while trying to save changes: ", dbEx);
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Database error while trying to save changes: ", dbEx);
            }
            catch (Exception dbEx)
            {
                throw new Exception("Database general error while trying to save changes: ", dbEx);
            }
        }

        private async Task<int> CommitAsync()
        {

            try
            {
                return await this._dbContext.CommitAsync();
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception("Database Concurrency error while trying to save changes: ", dbEx);
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Database error while trying to save changes: ", dbEx);
            }
            catch (Exception dbEx)
            {
                throw new Exception("Database general error while trying to save changes: ", dbEx);
            }

        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EFRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}