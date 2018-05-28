using Bueller.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuellerWebApi.Controllers
{
    [RoutePrefix("api/book")]
    public class BookController : ApiController
    {

            // GET: api/Assignments
            private readonly UnitOfWork unit = new UnitOfWork();
            private readonly BookRepo bookRepo;

            public BookController()
            {
                bookRepo = unit.BookRepo();
            }




            [HttpGet]
            [AllowAnonymous]
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
        [AllowAnonymous]
        [Route("GetbooksbyClassId/{id}")]
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

