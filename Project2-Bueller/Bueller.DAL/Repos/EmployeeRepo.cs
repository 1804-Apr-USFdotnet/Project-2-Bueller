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
    public class EmployeeRepo : Crud<Employee>
    {
        private readonly IDbContext _context;
        public EmployeeRepo(IDbContext context) : base(context)
        {

          
            _context = context;
        }

        public IEnumerable<EmployeeDto> GetEmployeesByType(string type)
        { 
            var employee =  this.Entities.Where(x => x.EmployeeType == type).ToList();
            return Mapper.Map<IEnumerable<EmployeeDto>>(employee);
        }

        public IEnumerable<Employee> GetEmployeesByNameAscending()
        {
            return this.Entities.OrderBy(x => x.FirstName).ToList();
        }
    }
}
