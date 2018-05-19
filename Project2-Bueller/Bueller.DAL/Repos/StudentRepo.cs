using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bueller.DA;
using Bueller.DA.Models;

namespace Bueller.DAL.Repos
{
    public class StudentRepo : Crud<Student>
    {
        private readonly IDbContext _context;
        public StudentRepo(IDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
