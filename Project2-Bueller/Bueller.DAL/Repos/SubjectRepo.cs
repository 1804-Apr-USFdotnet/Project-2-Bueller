using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bueller.DAL.Models;

namespace Bueller.DAL.Repos
{
    public class SubjectRepo : Crud<Subject>
    {
        private readonly IDbContext _context;
        public SubjectRepo(IDbContext context) : base(context)
        {
            _context = context;
        }

        public SubjectDto GetByName(string name)
        {
            var subject = this.Entities.Where(x => x.Name == name).FirstOrDefault();
            return Mapper.Map<SubjectDto>(subject);
        }

        public IEnumerable<Subject> GetSubjectsByDepartment(string department)
        {
            return this.Table.Where(x => x.Department.Equals(department)).ToList();
        }
    }
}
