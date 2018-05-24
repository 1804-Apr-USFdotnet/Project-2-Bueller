using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bueller.DA.Models;
using Bueller.DAL.Repos;

namespace Bueller.BLL
{
    public class CrossTable
    {
        private readonly UnitOfWork unit = new UnitOfWork();
        private ClassRepo classRepo;
        private FileRepo fileRepo;
        private EmployeeAccountRepo employeeAccountRepo;
        private EmployeeRepo employeeRepo;
        private StudentAccountRepo studentAccountRepo;
        private StudentRepo studentRepo;
        private GradeRepo gradeRepo;
        private SubjectRepo subjectRepo;


        public CrossTable()
        {
            classRepo = unit.ClassRepo();
            fileRepo = unit.FileRepo();
            employeeAccountRepo = unit.EmployeeAccountRepo();
            employeeRepo = unit.EmployeeRepo();
            studentAccountRepo = unit.StudentAccountRepo();
            studentRepo = unit.StudentRepo();
            gradeRepo = unit.GradeRepo();
            subjectRepo = unit.SubjectRepo();
        }

        public IEnumerable<Grade> GetGradesByStudentId(int id)
        {
            var grades = gradeRepo.Table
                .Join(fileRepo.Table, x => x.FileId, y => y.FileId, (x, y) => new { Grade = x, File = y })
                .Where(xy => xy.File.StudentId == id);

            var result = new List<Grade>();

            foreach (var var in grades)
            {
                result.Add(var.Grade);
            }

            return result;

        }
    }
}
