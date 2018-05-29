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
    public class GradeRepo : Crud<Grade>
    {
        private readonly IDbContext _context;
        public GradeRepo(IDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<GradeDto> GetFailingGrades()
        {
            var temp = this.Entities.Where(x => x.GradeLetter.Equals("F"));
            return Mapper.Map<IEnumerable<GradeDto>>(temp);
        }
    }
}
