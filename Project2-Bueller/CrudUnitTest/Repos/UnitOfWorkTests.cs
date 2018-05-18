﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bueller.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bueller.DA.Models;

namespace Bueller.DAL.Repos.Tests
{
    [TestClass()]
    public class UnitOfWorkTests
    {
        private UnitOfWork unit = new UnitOfWork();
        private readonly Crud<Employee> EmpCrud;

        public UnitOfWorkTests()
        {
            EmpCrud = unit.Crud<Employee>();
        }

        [TestMethod()]
        public void UnitOfWorkTest()
        {
            var em = EmpCrud.Table.Where(x => x.FirstName == "f").FirstOrDefault();

            Assert.AreEqual("f", em.FirstName);
        }
    }
}