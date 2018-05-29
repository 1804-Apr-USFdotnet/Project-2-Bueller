using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Bueller.DAL.Repos;

namespace BuellerWebApi.Controllers
{
    [System.Web.Mvc.RoutePrefix("Home")]
    public class HomeController : ApiController
    {
        private EmployeeRepo employeeRepo;
        private StudentRepo studentRepo;
        private ClassRepo classRepo;
        private UnitOfWork unit = new UnitOfWork();

        public HomeController()
        {
            employeeRepo = unit.EmployeeRepo();
            studentRepo = unit.StudentRepo();
            classRepo = unit.ClassRepo();
        }

        [HttpGet]
        [Route("GetHome")]
        public IHttpActionResult GetHome()
        {
            Tuple<int, int, int> result;
            int classes = classRepo.Table.Count();
            int teachers = employeeRepo.Table.Count(x => x.EmployeeType == "teacher");
            int students = studentRepo.Table.Count();

            result = new Tuple<int, int, int>(classes, teachers, students);

            return Ok(result);
        }
    }
}
