using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuellerWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bueller.BLL;

namespace BuellerWebApi.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void GetHomeTest()
        {
            CrossTable cross = new CrossTable();

            var expected = cross.GetHome();

            var actual = 9;

            Assert.AreEqual(expected.Item1, actual);
        }
    }
}