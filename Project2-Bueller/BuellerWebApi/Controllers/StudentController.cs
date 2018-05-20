using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bueller.DA.Models;
using Bueller.DAL.Repos;

namespace BuellerWebApi.Controllers
{
    public class StudentController : ApiController
    {
        UnitOfWork unit = new UnitOfWork();
        Crud<Student> repo;
        StudentController()
        {
            repo = unit.Crud<Student>();
        }

        // GET: api/Student
        //public IEnumerable<Student> Get()
        //{
        //    return repo.Table.ToList();
        //}

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, repo.Table.ToList());
        }

        // GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
            var student = repo.GetById(id);
            if (student != null)
            {
                return Ok(student);
            }
            return NotFound();
        }

        // POST: api/Student
        public IHttpActionResult Post([FromBody] Student value)
        {
            //try
            //{
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repo.Insert(value);
            return Ok();
            //}
        }

        // PUT: api/Student/5
        public IHttpActionResult Put(int id, [FromBody]Student value)
        {
            //var student = repo.GetById(id);
            //repo.Update();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != value.StudentId)
            {
                return BadRequest();
            }

            try
            {
                //doesnt update date modified, not sure how to fix
                repo.Update(value);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!(repo.Table.Count(e => e.StudentId == id) > 0))
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

        // DELETE: api/Student/5
        public void Delete(int id)
        {
            var student = repo.GetById(id);
            repo.Delete(student);
        }
    }
}
