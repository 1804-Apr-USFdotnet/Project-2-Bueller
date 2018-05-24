﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Bueller.DA.Models;
using Bueller.DAL.Models;
using Bueller.DAL.Repos;
using Microsoft.AspNet.Identity;

namespace BuellerWebApi.Controllers
{
    [RoutePrefix("api/Class")]
    public class ClassController : ApiController
    {
        private readonly UnitOfWork unit = new UnitOfWork();
        private readonly ClassRepo classRepo;
        private readonly SubjectRepo subjectRepo;

        public ClassController()
        {
            classRepo = unit.ClassRepo();
            subjectRepo = unit.SubjectRepo();
        }

        #region Class

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAllClasses()
        {
            var classes = classRepo.Table.ToList();
            if (!classes.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }

            return Ok(classes);
        }


        [HttpGet]
        [Route("GetByTeacherEmail/{email}/")]
        public IHttpActionResult GetClassByTeacherEmail(string email)
        {
            var classes = classRepo.GetClassesByTeacherEmail(email);
            if (!classes.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }

            return Ok(classes);
        }
  

        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult Get(int id)
        {
            var result = classRepo.GetById(id);
            if (result == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }
            return Ok(result);
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

   
        [HttpPost]
        [Route("Add", Name = "AddClass")]
        public IHttpActionResult Post(ClassDto classDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            classRepo.Insert(Mapper.Map<Class>(classDto));

            return CreatedAtRoute("AddClass", new { id = classDto.ClassId }, classDto);
        }

      
        public IHttpActionResult Put(int id, ClassDto classDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classDto.ClassId)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }

            try
            {
                classRepo.Update(Mapper.Map<Class>(classDto));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
                {
                    return Content(HttpStatusCode.NotFound, "Item does not exist");
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

   
        [HttpDelete]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var result = classRepo.GetById(id);
            if (result == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }

            classRepo.Delete(result);

            return Ok();
        }

        private bool ClassExists(int id)
        {
            return classRepo.Table.Count(e => e.ClassId == id) > 0;
        }

        #endregion
        #region Subject

        [HttpGet]
        [Route("Subject/GetAll")]
        public IHttpActionResult GetAllSubjects()
        {
            var subjects = subjectRepo.Table.ToList();
            if (!subjects.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }

            return Ok(subjects);
        }

        [HttpGet]
        [Route("Subject/GetById/{id}")]
        public IHttpActionResult GetSubjectById(int id)
        {
            var subject = subjectRepo.GetById(id);
            if (subject == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }

            return Ok(subject);
        }

        [HttpPost]
        [Route("Subject/Add", Name = "AddSubject")]
        public IHttpActionResult AddSubject(SubjectDto subjectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            subjectRepo.Insert(Mapper.Map<Subject>(subjectDto));

            return CreatedAtRoute("AddSubject", new { id = subjectDto.SubjectId }, subjectDto);
        }

        [HttpPut]
        [Route("Subject/AddAt/{id}")]
        public IHttpActionResult AddSubjectAt(int id, SubjectDto subjectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectDto.SubjectId)
            {
                return BadRequest();
            }

            try
            {
                subjectRepo.Update(Mapper.Map<Subject>(subjectDto));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
                {
                    return Content(HttpStatusCode.NotFound, "Item does not exist");
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NotFound);
        }

        [HttpDelete]
        [Route("Subject/Delete/{id}")]
        public IHttpActionResult DeleteSubject(int id)
        {
            var subject = subjectRepo.GetById(id);
            if (subject == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }

            return Ok(subject);
        }

        private bool SubjectExists(int id)
        {
            return subjectRepo.Table.Count(e => e.SubjectId == id) > 0;
        }



        #endregion
    }
}