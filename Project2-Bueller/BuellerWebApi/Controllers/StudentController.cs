using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using AutoMapper;
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

        public StudentController()
        {
            repo = unit.StudentRepo();
            accountRepo = unit.StudentAccountRepo();
        }

        #region Student
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult Get()
        {
            var students = repo.Table.ToList();
            if (!students.Any())
            {
                return Content(HttpStatusCode.NoContent, "List is empty");
            }

            return Ok(students);
        }

        [HttpGet]
        [Route("GetLoginInfo")]
        public IHttpActionResult GetLoginInfo()
        {
            // making use of global authorize filter in webapiconfig / filterconfig

            // get the currently logged-in user
            var user = Request.GetOwinContext().Authentication.User;

            // get his username
            string username = user.Identity.Name;

            // get whether user has some role
            bool isAdmin = user.IsInRole("admin");

            // get all user's roles
            List<string> roles = user.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value.ToString()).ToList();

            return Ok($"Authenticated {username}, with roles: [{string.Join(", ", roles)}]!");
        }

        // GET: api/Student/5
        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult Get(int id)
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
        public IHttpActionResult Post(StudentDto studentDto)
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
        public IHttpActionResult Put(int id, StudentDto studentDto)
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
