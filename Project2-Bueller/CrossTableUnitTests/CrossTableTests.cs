using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bueller.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.BLL.Tests
{
    [TestClass()]
    public class CrossTableTests
    {
        [TestMethod()]
        public void GetGradesByStudentIdTest()
        {
            CrossTable cross = new CrossTable();

            var expected = "test";

            var actual = cross.GetGradesByStudentId(2);

            Assert.AreEqual(expected,actual.First().EvaluationType);
        }
    }
}