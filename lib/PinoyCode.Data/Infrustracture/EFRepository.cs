using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Data.Infrustracture
{

    public class EFRepository<T> : IEFRepository<T> where T : class, new()
    {
        private readonly IDbContext _content;
        public EFRepository(IDbContext content)
        {
            this._content = content;
        }

        public virtual T GetById(object Id)
        {
            return this.Table.Find(Id);
        }

        public async Task<T> GetByIdAsync(object Id)
        {
            return await this.Table.FindAsync(Id);
        }

        public virtual void Add(T entity)
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

        public virtual void Update(T entity)
        {
            this.Table.Update(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                this.Table.Update(entity);
            });

        }

        public virtual void Delete(T entity)
        {
            this.Table.Remove(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                this.Table.Remove(entity);
            });

        }

        public virtual IQueryable<T> QueryAsTracking
        {
            get
            {
                return this.Table.AsTracking();
            }
        }

        public virtual IQueryable<T> QueryAsNoTracking
        {
            get
            {
                return this.Table.AsNoTracking();
            }
        }

        protected virtual DbSet<T> Table
        {
            get
            {
                return this._content.Table<T>();
            }
        }

        protected int Commit()
        {
            try
            {
                return this._content.Commit();
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

        protected async Task<int> CommitAsync()
        {
            return await Task<int>.Run(() =>
            {
                try
                {
                    return this._content.CommitAsync();
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
            });

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