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
    public class FileRepo : Crud<File>
    {
        private readonly IDbContext _context;
        public FileRepo(IDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<FileDto> GetFilesByStudentId(int id)
        {
            var temp = this.Entities.Where(x => x.StudentId == id).ToList();
            return Mapper.Map<IEnumerable<FileDto>>(temp);
        }
        public IEnumerable<FileDto> GetFilesByName(string name)
        {
            var temp = this.Entities.Where(x => x.FileName == name).ToList();
            return Mapper.Map<IEnumerable<FileDto>>(temp);
        }

        public IEnumerable<FileDto> GetFilesByClassId(int classId)
        {
            var temp = this.Entities.Where(x => x.Assignment.ClassId == classId).ToList();
            return Mapper.Map<IEnumerable<FileDto>>(temp);
        }

        public IEnumerable<FileDto> GetByAsnIdAndStudentId(int studentId, int assignmentId)
        {
            var temp = this.Entities.Where(x => x.StudentId == studentId);
            var temp2 = temp.Where(y => y.AssignmentId == assignmentId).ToList();
            return Mapper.Map<IEnumerable<FileDto>>(temp2);
        }
    }
}
