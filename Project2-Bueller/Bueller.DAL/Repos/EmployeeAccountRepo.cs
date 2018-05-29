using AutoMapper;
using Bueller.DA.Models;
using Bueller.DAL.Models;
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

        public IEnumerable<EmployeeAccountDto> GetAccountsByPayPeriod(string payPeriod)
        {
            var temp = this.Entities.Where(x => x.PayPeriod.Equals(payPeriod));
            return Mapper.Map<IEnumerable<EmployeeAccountDto>>(temp);
        }

        public EmployeeAccountDto GetAccountByEmployeeId(int id)
        {
            var temp = this.Entities.Where(x => x.EmployeeId == id).FirstOrDefault();
            return Mapper.Map<EmployeeAccountDto>(temp);
        }
    }
}
