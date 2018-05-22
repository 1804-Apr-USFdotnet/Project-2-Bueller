using AutoMapper;
using Bueller.DA.Models;
using Bueller.DAL.Models;
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
    [RoutePrefix("api")]
    public class FileGradeController : ApiController
    {
        private readonly UnitOfWork unit = new UnitOfWork();
        private readonly FileRepo fileRepo;
        private readonly GradeRepo gradeRepo;

        public FileGradeController()
        {
            fileRepo = unit.FileRepo();
            gradeRepo = unit.GradeRepo();
        }
        #region File
        [HttpGet]
        [Route("File/GetAll")]
        public IHttpActionResult GetAllFiles()
        {
            var files = fileRepo.Table.ToList();
            if (files.Count() == 0)
            {
                return NotFound();
            }
            return Ok(files);
        }

        [HttpGet]
        [Route("File/GetById/{id}")]
        public IHttpActionResult GetFileById(int id)
        {
            var file = fileRepo.GetById(id);
            if (file == null)
            {
                return NotFound();
            }
            return Ok(file);
        }

        [HttpPost]
        [Route("File/Add", Name = "AddFile")]
        public IHttpActionResult Post(FileDto file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            fileRepo.Insert(Mapper.Map<File>(file));

            return CreatedAtRoute("AddFile", new { id = file.FileId }, file);
        }

        [HttpPut]
        [Route("File/AddAt/{id}")]
        public IHttpActionResult Put(int id, FileDto file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != file.FileId)
            {
                return BadRequest();
            }
            try
            {
                fileRepo.Update(Mapper.Map<File>(file));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileExists(id))
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

        [HttpDelete]
        [Route("File/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var file = fileRepo.GetById(id);
            if (file == null)
            {
                return NotFound();
            }
            fileRepo.Delete(file);
            return Ok(file);
        }

        [HttpGet]
        [Route("File/GetByStudentId/{id}")]
        public IHttpActionResult GetFilesByStudentId(int id)
        {
            var files = fileRepo.GetFilesByStudentId(id);
            if (files.Count() == 0)
            {
                return NotFound();
            }
            return Ok(files);
        }

        [HttpGet]
        [Route("File/GetByName/{name}")]
        public IHttpActionResult GetFilesByName(string name)
        {
            var files = fileRepo.GetFilesByName(name);
            if (files.Count() == 0)
            {
                return NotFound();
            }
            return Ok(files);
        }

        private bool FileExists(int id)
        {
            return fileRepo.Table.Count(e => e.FileId == id) > 0;
        }
        #endregion
        #region Grade
        [HttpGet]
        [Route("Grade/GetAll")]
        public IHttpActionResult GetAllGrades()
        {
            var grades = gradeRepo.Table.ToList();
            if (grades.Count() == 0)
            {
                return NotFound();
            }
            return Ok(grades);
        }

        [HttpGet]
        [Route("Grade/GetById/{id}")]
        public IHttpActionResult GetGradeById(int id)
        {
            var grade = gradeRepo.GetById(id);
            if (grade == null)
            {
                return NotFound();
            }
            return Ok(grade);
        }

        [HttpPost]
        [Route("Grade/Add", Name = "AddGrade")]
        public IHttpActionResult AddGrade(GradeDto grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            gradeRepo.Insert(Mapper.Map<Grade>(grade));

            return CreatedAtRoute("AddGrade", new { id = grade.GradeId }, grade);
        }

        [HttpPut]
        [Route("Grade/AddAt/{id}")]
        public IHttpActionResult AddGradeAt(int id, GradeDto grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grade.GradeId)
            {
                return BadRequest();
            }

            try
            {
                gradeRepo.Update(Mapper.Map<Grade>(grade));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
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

        [HttpDelete]
        [Route("Grade/Delete/{id}")]
        public IHttpActionResult DeleteGrade(int id)
        {
            var grade = gradeRepo.GetById(id);
            if (grade == null)
            {
                return NotFound();
            }
            gradeRepo.Delete(Mapper.Map<Grade>(grade));

            return Ok(grade);
        }

        [HttpGet]
        [Route("Grade/GetFailing")]
        public IHttpActionResult GetFailingGrade()
        {
            var grades = gradeRepo.GetFailingGrades();
            if (grades.Count() == 0)
            {
                return NotFound();
            }
            return Ok(grades);
        }

        private bool GradeExists(int id)
        {
            return gradeRepo.Table.Count(e => e.FileId == id) > 0;
        }
        #endregion
    }
}
