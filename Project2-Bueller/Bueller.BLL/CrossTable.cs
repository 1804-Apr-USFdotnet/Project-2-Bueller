using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bueller.DA.Models;
using Bueller.DAL.Models;
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

        public void EnrollStudent(int classid, int studentid)
        {
            var student = studentRepo.GetById(studentid);
            var classresult = classRepo.GetById(classid);
            classresult.Students.Add(student);
            unit.SaveChanges();

            //var student1 = _context.Set<Student>().FirstOrDefault(s => s.FirstName == "bobby");
            //var class1 = _context.Set<Class>().Find(3);
            //class1.Students.Add(student1);

            //_context.SaveChanges();
        }

        public IEnumerable<GradeDto> GetGradesByStudentId(int id)
        {
            var grades = gradeRepo.Table
                .Join(fileRepo.Table, x => x.FileId, y => y.FileId, (x, y) => new { Grade = x, File = y })
                .Where(xy => xy.File.StudentId == id);

            var result = new List<Grade>();

            foreach (var var in grades)
            {
                result.Add(var.Grade);
            }

            return Mapper.Map<IEnumerable<GradeDto>>(result);
        }

        public IEnumerable<StudentDto> GetStudentsByTeacherId(int id)
        {
            var classes = classRepo.Table.Where(x => x.TeacherId == id).ToList();
            var students = classes.SelectMany(x => x.Students).Distinct();

            return Mapper.Map<IEnumerable<StudentDto>>(students).ToList();
        }

        public IEnumerable<EmployeeDto> GetTeachersByStudnetId(int id)
        {
            var classes = GetClassesByStudentId(id);
            var teachers = classes.Select(x => x.Teacher).Where(x => x != null).Distinct().ToList();

            return Mapper.Map<IEnumerable<EmployeeDto>>(teachers);
        }

        public IEnumerable<ClassDto> GetClassesByStudentId(int id)
        {
            var classes = classRepo.Table.Where(x => x.Students.Any(y => y.StudentId == id)).ToList();

            return Mapper.Map<IEnumerable<ClassDto>>(classes);
        }
    }
}
