using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Bueller.BLL;
using Bueller.DAL.Repos;

namespace BuellerWebApi.Controllers
{
    [System.Web.Mvc.RoutePrefix("Home")]
    public class HomeController : ApiController
    {
        private readonly CrossTable cross = new CrossTable();


        [HttpGet]
        [Route("GetHome")]
        public IHttpActionResult GetHome()
        {
            var result = cross.GetHome();
            return Ok(result);
        }
    }
}
