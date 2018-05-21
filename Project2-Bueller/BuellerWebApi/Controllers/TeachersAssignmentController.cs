using Bueller.DA;
using Bueller.DA.Models;
using Bueller.DAL;
using Bueller.DAL.Repos;
using BuellerWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuellerWebApi.Controllers
{


    //[Authorize(Roles = "Admin, Teacher")]
    public class TeachersAssignmentController : ApiController
    {

      

        
        public IHttpActionResult GetAssignment()
        {
            return null;
        }



        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
