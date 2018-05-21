using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bueller.DA.Models;

namespace Bueller.DAL.Repos
{
    public class StudentAccountRepo : Crud<StudentAccount>
    {
        private readonly IDbContext _context;
        public StudentAccountRepo(IDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<StudentAccount> GetAccountsOwed()
        {
            return this.Entities.Where(x => x.BalanceOwed > 0).ToList();
        }

        public IEnumerable<StudentAccount> GetAccountsWithAid()
        {
            return this.Entities.Where(x => x.Aid > 0).ToList();
        }

        public IEnumerable<StudentAccount> GetByAmountOwed(double owed)
        {
            return this.Entities.Where(x => x.BalanceOwed > owed).ToList();
        }

        public StudentAccount GetAccountByStudentId(int id)
        {
            return this.Entities.Where(x => x.StudentId == id).FirstOrDefault();
        }
    }
}
