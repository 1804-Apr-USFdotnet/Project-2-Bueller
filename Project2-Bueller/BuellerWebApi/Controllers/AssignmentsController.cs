using Bueller.DA.Models;
using Bueller.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuellerWebApi.Controllers
{
    [RoutePrefix("api/Assignment")]
    public class AssignmentsController : ApiController
    {
        // GET: api/Assignments
        private readonly UnitOfWork unit = new UnitOfWork();
        private readonly AssignmentRepo assignmentRepo;

        AssignmentsController()
        {
            assignmentRepo = unit.AssignmentRepo();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAssignments()
        {
            IEnumerable<Assignment> assignments = assignmentRepo.Table.ToList();
            if (assignments.Count() == 0)
            {
                return Ok(assignments);
            }
            return Ok(assignments);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            Assignment assignment = assignmentRepo.GetById(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        [HttpPost]
        [Route("Add", Name = "AddAssignment")]
        public IHttpActionResult Post(Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            assignmentRepo.Insert(assignment);

            return CreatedAtRoute("AddAssignment", new { id = assignment.AssignmentId }, assignment);
        }

        [HttpPut]
        [Route("AddAt/{id}")]
        public IHttpActionResult Put(int id, Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignment.AssignmentId)
            {
                return BadRequest();
            }

            try
            {
                assignmentRepo.Update(assignment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);

        }

        [HttpPost]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            Assignment assignment = assignmentRepo.GetById(id);
            if (assignment == null)
            {
                return NotFound();
            }
            assignmentRepo.Delete(assignment);

            return Ok(assignment);
        }

        private bool AssignmentExists(int id)
        {
            return assignmentRepo.Table.Count(e => e.AssignmentId == id) > 0;
        }
    }
}
