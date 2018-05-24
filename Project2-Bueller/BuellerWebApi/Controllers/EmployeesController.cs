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
        public IHttpActionResult GetEmployees()
        {
            var employees = repo.Table.ToList();
            if (!employees.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }
            return Ok(employees);
        }
        
        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var employee = repo.GetById(id);
            if (employee == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }
            return Ok(employee);
        }
        
        [HttpPost]
        [Route("Add", Name = "AddEmployee")]
        public IHttpActionResult AddEmployee(EmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Insert(Mapper.Map<Employee>(employee));

            return CreatedAtRoute("AddEmployee", new { id = employee.EmployeeID }, employee);
        }
        
        [HttpPut]
        [Route("AddAt/{id}")]
        public IHttpActionResult UpdateEmployee(int id, EmployeeDto employee)
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
                repo.Update(Mapper.Map<Employee>(employee));
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = repo.GetById(id);
            if (employee == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }

            repo.Delete(employee);

            return Ok(employee);
        }

        [HttpGet]
        [Route("Type/{type}")]
        public IHttpActionResult GetEmployeesByType(string type)
        {
            var employees = repo.GetEmployeesByType(type);
            if (!employees.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }

            return Ok(employees);
        }

        [HttpGet]
        [Route("Name")]
        public IHttpActionResult GetEmployeesByNameAscending()
        {
            var employees = repo.GetEmployeesByNameAscending();
            if (!employees.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }

            return Ok(employees);
        }

        private bool EmployeeExists(int id)
        {
            return repo.Table.Count(e => e.EmployeeID == id) > 0;
        }

        #endregion
        #region Employee Accounts
        [HttpGet]
        [Route("Account/GetAll")]
        public IHttpActionResult GetEmployeeAccounts()
        {
            var accounts = accountRepo.Table.ToList();
            if (!accounts.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }
            return Ok(accounts);
        }

        [HttpPost]
        [Route("Account/Add", Name = "AddEmplyeeAccount")]
        public IHttpActionResult AddEmployeeAccount(int employeeID, EmployeeAccountDto employeeAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            accountRepo.Insert(Mapper.Map<EmployeeAccount>(employeeAccount));

            return CreatedAtRoute("AddEmployeeAccount", new { id = employeeAccount.EmployeeAccountId }, employeeAccount);
        }

        [HttpDelete]
        [Route("Account/Delete/{id}")]
        public IHttpActionResult DeleteEmployeeAccount(int id)
        {
            var employeeAccount = accountRepo.GetById(id);
            if (employeeAccount == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }

            accountRepo.Delete(employeeAccount);

            return Ok(employeeAccount);
        }

        [HttpGet]
        [Route("Account/GetById/{id}")]
        public IHttpActionResult GetEmployeeAccountById(int id)
        {
            var employeeAccount = accountRepo.GetById(id);
            if (employeeAccount == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }
            return Ok(employeeAccount);
        }

        [HttpGet]
        [Route("Account/GetByEmployeeId/{id}")]
        public IHttpActionResult GetAccountByEmployeeId(int id)
        {
            var employeeAccount = accountRepo.GetAccountByEmployeeId(id);
            if (employeeAccount == null)
            {
                return Content(HttpStatusCode.NotFound, "Item does not exist");
            }
            return Ok(employeeAccount);
        }

        [HttpGet]
        [Route("Account/GetByPayPeriod/{period}")]
        public IHttpActionResult GetAccountsByPayPeriod(string period)
        {
            var employeeAccounts = accountRepo.GetAccountsByPayPeriod(period);
            if (!employeeAccounts.Any())
            {
                return Content(HttpStatusCode.NotFound, "List is empty");
            }
            return Ok(employeeAccounts);
        }

        [HttpPut]
        [Route("Account/AddAt/{id}")]
        public IHttpActionResult AddAccountAt(int id, EmployeeAccountDto employeeAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != employeeAccount.EmployeeAccountId)
            {
                return BadRequest();
            }

            try
            {
                accountRepo.Update(Mapper.Map<EmployeeAccount>(employeeAccount));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeAccountExists(id))
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

        private bool EmployeeAccountExists(int id)
        {
            return accountRepo.Table.Count(e => e.EmployeeAccountId == id) > 0;
        }
        #endregion
    }
}
