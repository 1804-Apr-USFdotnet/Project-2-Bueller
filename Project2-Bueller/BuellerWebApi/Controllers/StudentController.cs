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
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        private readonly UnitOfWork unit = new UnitOfWork();
        private readonly Crud<Student> repo;
        private readonly StudentAccountRepo accountRepo;

        StudentController()
        {
            repo = unit.Crud<Student>();
            accountRepo = unit.StudentAccountRepo();
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

        #region Student Account
        [HttpGet]
        [Route("Account/GetAll")]
        public IEnumerable<StudentAccount> GetStudentAccounts()
        {
            return accountRepo.Table.ToList();
        }

        [HttpPost]
        [Route("Account/Add", Name = "AddStudentAccount")]
        public IHttpActionResult AddStudentAccount(int StudentID, StudentAccount StudentAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            accountRepo.Insert(StudentAccount);

            return CreatedAtRoute("AddStudentAccount", new { id = StudentAccount.StudentAccountId }, StudentAccount);
        }

        [HttpPost]
        [Route("Account/Delete/{id}")]
        public IHttpActionResult DeleteStudentAccount(int id)
        {
            StudentAccount StudentAccount = accountRepo.GetById(id);
            if (StudentAccount == null)
            {
                return NotFound();
            }

            accountRepo.Delete(StudentAccount);

            return Ok(StudentAccount);
        }

        [HttpGet]
        [Route("Account/GetById/{id}")]
        public IHttpActionResult GetStudentAccountById(int id)
        {
            StudentAccount StudentAccount = accountRepo.GetById(id);
            if (StudentAccount == null)
            {
                return NotFound();
            }
            return Ok(StudentAccount);
        }

        [HttpGet]
        [Route("Account/Owed")]
        public IHttpActionResult GetAccountsOwed()
        {
            IEnumerable<StudentAccount> studentAccounts = accountRepo.GetAccountsOwed();
            if (studentAccounts.Count() == 0)
            {
                return NotFound();
            }
            return Ok(studentAccounts);
        }

        [HttpGet]
        [Route("Account/WithAid")]
        public IHttpActionResult GetAccountsWithAid()
        {
            IEnumerable<StudentAccount> studentAccounts = accountRepo.GetAccountsWithAid();
            if (studentAccounts.Count() == 0)
            {
                return NotFound();
            }
            return Ok(studentAccounts);
        }

        [HttpGet]
        [Route("Account/Owed/{owed}")]
        public IHttpActionResult GetAccountsByAmountOwed(double owed)
        {
            IEnumerable<StudentAccount> studentAccounts = accountRepo.GetByAmountOwed(owed);
            if (studentAccounts.Count() == 0)
            {
                return NotFound();
            }
            return Ok(studentAccounts);
        }

        #endregion
    }
}
