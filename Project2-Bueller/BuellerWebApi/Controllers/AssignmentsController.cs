using Bueller.DA.Models;
using Bueller.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuellerWebApi.Controllers
{
    public class AssignmentsController : ApiController
    {
        // GET: api/Assignments
        private readonly UnitOfWork unit = new UnitOfWork();
        private readonly AssignmentRepo assignmentRepo;

        AssignmentsController()
        {
            assignmentRepo = unit.AssignmentRepo();
        }

        public IHttpActionResult GetAssignments()
        {
            IEnumerable<Assignment> assignments = assignmentRepo.Table.ToList();
            if (assignments.Count() == 0)
            {
                return NotFound();
            }
            return Ok(assignments);
        }

        // GET: api/Assignments/5
        public IHttpActionResult Get(int id)
        {
            Assignment assignment = assignmentRepo.GetById(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        // POST: api/Assignments
        public IHttpActionResult Post(Assignment assignment)
        {
        }

        // PUT: api/Assignments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Assignments/5
        public void Delete(int id)
        {
        }
    }
}
