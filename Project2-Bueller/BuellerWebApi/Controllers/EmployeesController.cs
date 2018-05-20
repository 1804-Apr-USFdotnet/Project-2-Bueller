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
    [RoutePrefix("api/Employee")]
    public class EmployeesController : ApiController
    {
        private readonly UnitOfWork unit = new UnitOfWork();
        private readonly EmployeeRepo repo;
        private readonly EmployeeAccountRepo accountRepo;

        EmployeesController()
        {
            repo = unit.EmployeeRepo();
            accountRepo = unit.EmployeeAccountRepo();
        }

        #region Employees
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Employee> GetEmployees()
        {
            return repo.Table.ToList();
        }

        // GET: api/Employees/5
        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult GetEmployeeById(int id)
        {
            Employee employee = repo.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost]
        [Route("Add", Name = "AddEmployee")]
        public IHttpActionResult AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Insert(employee);

            return CreatedAtRoute("AddEmployee", new { id = employee.EmployeeID }, employee);
        }

        // PUT: api/Employees/5
        [HttpPut]
        [Route("AddAt/{id}")]
        public IHttpActionResult UpdateEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }

            try
            {
                //doesnt update date modified, not sure how to fix
                repo.Update(employee);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // DELETE: api/Employees/{id}
        [HttpPost]
        [Route("Delete/{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = repo.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            repo.Delete(employee);

            return Ok(employee);
        }

        [HttpGet]
        [Route("Type/{type}")]
        public IHttpActionResult GetEmployeesByType(string type)
        {
            IEnumerable<Employee> employees = repo.GetEmployeesByType(type);
            if (employees.Count() == 0)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        [HttpGet]
        [Route("Name")]
        public IHttpActionResult GetEmployeesByNameAscending()
        {
            IEnumerable<Employee> employees = repo.GetEmployeesByNameAscending();
            if (employees.Count() == 0)
            {
                return NotFound();
            }

            return Ok(employees);
        }
        #endregion
        #region Employee Accounts
        [HttpGet]
        [Route("Account/GetAll")]
        public IEnumerable<EmployeeAccount> GetEmployeeAccounts()
        {
            return accountRepo.Table.ToList();
        }

        [HttpPost]
        [Route("Account/Add", Name = "AddEmplyeeAccount")]
        public IHttpActionResult AddEmployeeAccount(int employeeID, EmployeeAccount employeeAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            accountRepo.Insert(employeeAccount);

            return CreatedAtRoute("AddEmployeeAccount", new { id = employeeAccount.EmployeeAccountId }, employeeAccount);
        }

        [HttpPost]
        [Route("Account/Delete/{id}")]
        public IHttpActionResult DeleteEmployeeAccount(int id)
        {
            EmployeeAccount employeeAccount = accountRepo.GetById(id);
            if (employeeAccount == null)
            {
                return NotFound();
            }

            accountRepo.Delete(employeeAccount);

            return Ok(employeeAccount);
        }

        [HttpGet]
        [Route("Account/GetById/{id}")]
        public IHttpActionResult GetEmployeeAccountById(int id)
        {
            EmployeeAccount employeeAccount = accountRepo.GetById(id);
            if (employeeAccount == null)
            {
                return NotFound();
            }
            return Ok(employeeAccount);
        }

        [HttpGet]
        [Route("Account/GetByEmployeeId/{id}")]
        public IHttpActionResult GetAccountByEmployeeId(int id)
        {
            EmployeeAccount employeeAccount = accountRepo.GetAccountByEmployeeId(id);
            if (employeeAccount == null)
            {
                return NotFound();
            }
            return Ok(employeeAccount);
        }

        [HttpGet]
        [Route("Account/GetByPayPeriod/{period}")]
        public IHttpActionResult GetAccountsByPayPeriod(string period)
        {
            IEnumerable<EmployeeAccount> employeeAccounts = accountRepo.GetAccountsByPayPeriod(period);
            if (employeeAccounts.Count() == 0)
            {
                return NotFound();
            }
            return Ok(employeeAccounts);
        }
        #endregion

        private bool EmployeeExists(int id)
        {
            return repo.Table.Count(e => e.EmployeeID == id) > 0;
        }
    }
}
