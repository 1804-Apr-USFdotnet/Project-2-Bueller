using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Bueller.DA;

namespace Bueller.DAL.Repos
{
    //does not work correctly right now, just use a crud repo
    //allows for dbcontext to not be referenced in web controllers
    public class UnitOfWork : IDisposable
    {
        private readonly IDbContext _context;
        private bool _disposed;
        private Dictionary<string, object> _repositories;

        public UnitOfWork()
        {
            _context = new BuellerContext();
        }

        public UnitOfWork(IDbContext context)
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
                    _context.Dispose();
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
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (Crud<T>)_repositories[type];
        }

        public EmployeeRepo EmployeeRepo()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(Employee).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(EmployeeRepo);
                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (EmployeeRepo)_repositories[type];
        }

        public EmployeeAccountRepo EmployeeAccountRepo()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(EmployeeAccount).Name;

            if (!_repositories.ContainsKey(type))
            {
                var resositoryType = typeof(EmployeeAccountRepo);
                var repositoryInstance = Activator.CreateInstance(resositoryType, _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (EmployeeAccountRepo)_repositories[type];
        }

        public StudentAccountRepo StudentAccountRepo()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(StudentAccount).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(StudentAccountRepo);
                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (StudentAccountRepo)_repositories[type];
        }

        public AssignmentRepo AssignmentRepo()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(AssignmentRepo).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(AssignmentRepo);
                var repositoryInstace = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(type, repositoryInstace);
            }

            return (AssignmentRepo)_repositories[type];
        }

        public FileRepo FileRepo()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(FileRepo).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(FileRepo);
                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (FileRepo)_repositories[type];
        }

        public GradeRepo GradeRepo()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(GradeRepo).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GradeRepo);
                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (GradeRepo)_repositories[type];
        }

        public ClassRepo ClassRepo()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(ClassRepo).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(ClassRepo);
                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (ClassRepo)_repositories[type];
        }
        public StudentRepo StudentRepo()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(StudentRepo).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(StudentRepo);
                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (StudentRepo)_repositories[type];
        }

        public SubjectRepo SubjectRepo()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(SubjectRepo).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(SubjectRepo);
                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (SubjectRepo)_repositories[type];
        }
    }
}
