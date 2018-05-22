using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DAL.Repos
{
    public class SubjectRepo : Crud<Subject>
    {
        private readonly IDbContext _context;
        public SubjectRepo(IDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
