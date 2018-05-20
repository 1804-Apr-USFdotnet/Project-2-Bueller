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
    public class ClassController : ApiController
    {
        UnitOfWork unit = new UnitOfWork();
        private Crud<Class> classRepo;
        private Crud<Student> studentRepo;

        ClassController()
        {
            classRepo = unit.Crud<Class>();
            studentRepo = unit.Crud<Student>();
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

        [Route("~/api/Class/StudentClasses/{id}")]
        public IHttpActionResult StudentClasses(int id)
        {
            //studentRepo.AddToClass();
            //var classes = studentRepo.Table.Where(x => x.StudentId == id).SelectMany(x => x.Classes);
            var classes = classRepo.Table.Where(x => x.Students.Any(a => a.StudentId == id));
            //models need to be mapped to remove reference loops in serializing database models
            //List<string> test = new List<string>();
            //foreach (var classres in classes)
            //{
            //    test.Add(classres.Name);
            //}
            if (classes != null)
            {
                return Ok(classes.Count());
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
