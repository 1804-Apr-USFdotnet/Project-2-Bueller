using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DAL.Repos
{
    public class EmployeeAccountRepo : Crud<EmployeeAccount>
    {
        private readonly IDbContext _context;
        public EmployeeAccountRepo(IDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeAccount> GetAccountsByPayPeriod(string payPeriod)
        {
            return this.Entities.Where(x => x.PayPeriod.Equals(payPeriod));
        }

        public EmployeeAccount GetAccountByEmployeeId(int id)
        {
            return this.Entities.Where(x => x.EmployeeId == id).FirstOrDefault();
        }
    }
}
