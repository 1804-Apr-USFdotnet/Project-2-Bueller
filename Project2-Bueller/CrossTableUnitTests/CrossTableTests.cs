using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bueller.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bueller.DAL.Models;

namespace Bueller.BLL.Tests
{
    [TestClass()]
    public class CrossTableTests
    {

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
        }

        [TestMethod()]
        public void GetGradesByStudentIdTest()
        {
            CrossTable cross = new CrossTable();

            var expected = "test";

            var actual = cross.GetGradesByStudentId(2);

            Assert.AreEqual(expected, actual.First().EvaluationType);
        }

        [TestMethod()]
        public void GetStudentsByTeacherIdTest()
        {
            CrossTable cross = new CrossTable();

            var expected = "bobby";

            var actual = cross.GetStudentsByTeacherId(8);

            Assert.AreEqual(expected, actual.First().FirstName);
        }

        [TestMethod()]
        public void GetClassesByStudentIdTest()
        {
            CrossTable cross = new CrossTable();

            var expected = "Biology";

            var actual = cross.GetClassesByStudentId(2);

            Assert.AreEqual(expected, actual.First().Name);
        }

        [TestMethod()]
        public void GetTeachersByStudnetIdTest()
        {
            CrossTable cross = new CrossTable();

            var expected = "First Name";

            var actual = cross.GetTeachersByStudnetId(2);

            Assert.AreEqual(expected, actual.First().FirstName);
        }
    }
}