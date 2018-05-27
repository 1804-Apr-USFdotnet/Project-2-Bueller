using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuellerWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bueller.DAL.Models;
using Bueller.DAL.Repos;

namespace BuellerWebApi.Controllers.Tests
{
    [TestClass()]
    public class FileGradeControllerTests
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
        public void GetFilesByStudentIdTest()
        {
            UnitOfWork unit = new UnitOfWork();
            FileRepo repo = unit.FileRepo();


            var expected = 2;

            var actual = repo.GetFilesByStudentId(7).First().FileId;

            Assert.AreEqual(expected,actual);
        }
    }
}