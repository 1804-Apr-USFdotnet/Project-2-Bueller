using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bueller.DA.Models;
using Bueller.DAL.Repos;
using Microsoft.AspNet.Identity;

namespace BuellerWebApi.Controllers
{
    [RoutePrefix("api/Class")]
    public class ClassController : ApiController
    {
        private readonly UnitOfWork unit = new UnitOfWork();
        private readonly ClassRepo classRepo;
        private readonly StudentRepo studentRepo;

        ClassController()
        {
            classRepo = unit.ClassRepo();
            studentRepo = unit.StudentRepo();
        }

        // GET: api/Class
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, classRepo.Table.ToList());
        }

        // GET: api/Class/5
        public IHttpActionResult Get(int id)
        {
            var result = classRepo.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("StudentClasses/{id}")]
        public IHttpActionResult StudentClasses(int id)
        {
            //studentRepo.AddToClass();
            //var classes = studentRepo.Table.Where(x => x.StudentId == id).SelectMany(x => x.Classes).ToList();
            var classes = classRepo.Table.Where(x => x.Students.Any(a => a.StudentId == id)).ToList();
            if (classes != null)
            {
                return Ok(classes);
            }
            return NotFound();
        }

        // POST: api/Class
        public IHttpActionResult Post([FromBody]Class value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            classRepo.Insert(value);
            return Ok();
        }

        // PUT: api/Class/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Class/5
        public void Delete(int id)
        {
            var classresult = classRepo.GetById(id);
            classRepo.Delete(classresult);
        }
    }
}
