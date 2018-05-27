using Bueller.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuellerWebApi.Controllers
{
    public class BookController : ApiController
    {

        [RoutePrefix("api/book")]
        public class AssignmentsController : ApiController
        {
            // GET: api/Assignments
            private readonly UnitOfWork unit = new UnitOfWork();
            private readonly BookRepo bookRepo;

            public AssignmentsController()
            {
                bookRepo = unit.BookRepo();
            }




            [HttpGet]
            [Route("GetAll")]
            public IHttpActionResult GetBooks()
            {
                var books = bookRepo.Table.ToList();
                if (!books.Any())
                {
                    return Content(HttpStatusCode.NotFound, "List is empty");
                }
                return Ok(books);
            }





            [HttpGet]
            [Route("GetbooksbyClassId/ {id}")]
            public IHttpActionResult GetBooksByClassId(int id)
            {
                var books = bookRepo.GetBookbyClassId(id);
                if (!books.Any())
                {
                    return Content(HttpStatusCode.NotFound, "List is empty");
                }
                return Ok(books);
            }
        }
    }

}
