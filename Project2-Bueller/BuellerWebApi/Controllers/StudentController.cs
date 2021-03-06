﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Bueller.BLL;
using Bueller.DA.Models;
using Bueller.DAL.Models;
using Bueller.DAL.Repos;

namespace BuellerWebApi.Controllers
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        private readonly UnitOfWork unit = new UnitOfWork();
        private readonly StudentRepo repo;
        private readonly StudentAccountRepo accountRepo;
        private CrossTable cross;

        public StudentController()
        {
            repo = unit.StudentRepo();
            accountRepo = unit.StudentAccountRepo();
            cross = new CrossTable();
        }

        #region Student
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetStudents()
        {
            var students = repo.Table.ToList();
            if (!students.Any())
            {
                return Content(HttpStatusCode.NoContent, "List is empty");
            }

            return Ok(students);
        }

        // GET: api/Student/5
        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var student = repo.GetById(id);
            if (student == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        [Route("Add", Name = "AddStudent")]
        public IHttpActionResult AddStudent(StudentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repo.Insert(Mapper.Map<Student>(studentDto));

            return CreatedAtRoute("AddStudent", new { id = studentDto.StudentId }, studentDto);
        }

        // PUT: api/Student/
        [HttpPut]
        [Route("AddAt/{id}")]
        public IHttpActionResult PutAt(int id, StudentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentDto.StudentId)
            {
                return BadRequest();
            }

            try
            {
                repo.Update(Mapper.Map<Student>(studentDto));
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // DELETE: api/Student/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var student = repo.GetById(id);
            if (student == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }

            repo.Delete(student);

            return Ok(student);
        }

        [HttpGet]
        [Route("GetGradesByStudentId/{id}")]
        public IHttpActionResult GetGradesByStudentId(int id)
        {
            var grades = cross.GetGradesByStudentId(id);
            if (!grades.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }

            return Ok(grades);
        }

        [HttpGet]
        [Route("GetTeachersByStudentId/{id}")]
        public IHttpActionResult GetTeachersByStudentId(int id)
        {
            var teachers = cross.GetTeachersByStudnetId(id);
            if (!teachers.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }

            return Ok(teachers);
        }

        [HttpGet]
        [Route("GetClassesByStudentId/{id}")]
        public IHttpActionResult GetClassesByStudentId(int id)
        {
            var classes = cross.GetClassesByStudentId(id);
            if (!classes.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }

            return Ok(classes);
        }

        private bool StudentExists(int id)
        {
            return repo.Table.Count(e => e.StudentId == id) > 0;
        }

        #endregion
        #region Student Account

        [HttpGet]
        [Route("Account/GetAll")]
        public IHttpActionResult GetStudentAccounts()
        {
            var accounts = accountRepo.Table.ToList();

            if (!accounts.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }

            return Ok(accounts);
        }

        [HttpPost]
        [Route("Account/Add", Name = "AddStudentAccount")]
        public IHttpActionResult AddStudentAccount(int id, StudentAccountDto StudentAccountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            accountRepo.Insert(Mapper.Map<StudentAccount>(StudentAccountDto));

            return CreatedAtRoute("AddStudentAccount", new { id = StudentAccountDto.StudentId }, StudentAccountDto);
        }

        [HttpDelete]
        [Route("Account/Delete/{id}")]
        public IHttpActionResult DeleteStudentAccount(int id)
        {
            var StudentAccount = accountRepo.GetById(id);

            if (StudentAccount == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }

            accountRepo.Delete(StudentAccount);

            return Ok(StudentAccount);
        }

        [HttpGet]
        [Route("Account/GetById/{id}")]
        public IHttpActionResult GetStudentAccountById(int id)
        {
            var StudentAccount = accountRepo.GetById(id);

            if (StudentAccount == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }
            return Ok(StudentAccount);
        }

        [HttpGet]
        [Route("Account/Owed")]
        public IHttpActionResult GetAccountsOwed()
        {
            var studentAccounts = accountRepo.GetAccountsOwed();
            if (!studentAccounts.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }
            return Ok(studentAccounts);
        }

        [HttpGet]
        [Route("Account/WithAid")]
        public IHttpActionResult GetAccountsWithAid()
        {
            var studentAccounts = accountRepo.GetAccountsWithAid();
            if (!studentAccounts.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }
            return Ok(studentAccounts);
        }

        [HttpGet]
        [Route("Account/Owed/{owed}")]
        public IHttpActionResult GetAccountsByAmountOwed(double owed)
        {
            var studentAccounts = accountRepo.GetByAmountOwed(owed);
            if (!studentAccounts.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }
            return Ok(studentAccounts);
        }

        [HttpGet]
        [Route("Account/GetByStudentId/{id}")]
        public IHttpActionResult GetAccountBytStudentId(int id)
        {
            var studentAccount = accountRepo.GetAccountByStudentId(id);
            if (studentAccount == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }
            return Ok(studentAccount);
        }

        #endregion
    }
}
