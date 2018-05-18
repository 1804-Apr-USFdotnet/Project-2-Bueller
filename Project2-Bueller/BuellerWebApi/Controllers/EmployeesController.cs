﻿using Bueller.DA.Models;
using Bueller.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuellerWebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        UnitOfWork unit = new UnitOfWork();
        EmployeeRepo repo;
        EmployeesController()
        {
            repo = unit.EmployeeRepo();
        }
        // GET: api/Employees
        public IEnumerable<Employee> Get()
        {
            return repo.Table.ToList();
        }

        // GET: api/Employees/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employees
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employees/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employees/5
        public void Delete(int id)
        {
        }
    }
}