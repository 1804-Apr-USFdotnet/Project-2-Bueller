using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bueller.DAL.Repos
{
    //allows for dbcontext to not be referenced in web controllers
    public class UnitOfWork : IDisposable
    {
        private readonly BuellerContext _context;
        private bool _disposed;
        private Dictionary<string, object> _repositories;

        public UnitOfWork()
        {
            _context = new BuellerContext();
        }

        public UnitOfWork(BuellerContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    ((IDbContext)_context).Dispose();
                }
            }
            _disposed = true;
        }

        public Crud<T> Crud<T>() where T : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Crud<>);
                var repositoryInstance = Activator.CreateInstance(typeof(Crud<T>), _context);
                _repositories.Add(type,repositoryInstance);
            }
            return (Crud<T>)_repositories[type];
        }
    }
}
