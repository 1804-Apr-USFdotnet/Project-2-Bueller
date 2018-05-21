using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DAL.Repos
{
    public class AssignmentRepo : Crud<Assignment>
    {
        private readonly IDbContext _context;
        public AssignmentRepo(IDbContext context): base(context)
        {
            _context = context;
        }

        public IEnumerable<Assignment> GetAssignmentsByClassId(int id)
        {
            return this.Entities.Where(x => x.ClassId == id).ToList();
        }

        public IEnumerable<Assignment> GetAssignmentsWithFiles()
        {
            return this.Entities.Where(x =>x.Files.Count > 0).ToList();
        }

        public IEnumerable<Assignment> GetAssignmentsByDueDate(DateTime duedate)
        {
            return this.Entities.Where(x => x.DueDate == duedate).ToList();
        }
    }
}
