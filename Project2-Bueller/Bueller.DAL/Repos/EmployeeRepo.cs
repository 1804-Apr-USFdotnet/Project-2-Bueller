using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DAL.Repos
{
    public class EmployeeRepo : Crud<Employee>
    {
        private readonly IDbContext _context;
        public EmployeeRepo(IDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
