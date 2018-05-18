﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bueller.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bueller.DA.Models;
using Bueller.DA;
using System.Data.Entity;

namespace Bueller.DAL.Repos.Tests
{
    [TestClass()]
    public class CrudTests
    {
        public ICrud<Employee> crud;
        public IDbContext context;
        public CrudTests()
        {
            context = new BuellerContext();
            crud = new Crud<Employee>(context);
        }
        [TestMethod()]
        public void InsertTest()
        {
            var em = crud.Table.Where(x => x.FirstName == "f").FirstOrDefault();
            Assert.AreEqual("f", em.FirstName);
        }
    }
}