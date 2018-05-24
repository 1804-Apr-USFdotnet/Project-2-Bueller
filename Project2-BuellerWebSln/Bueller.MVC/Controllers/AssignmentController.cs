using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Bueller.MVC.Models;
using Newtonsoft.Json;

namespace Bueller.MVC.Controllers
{
    public class AssignmentController : AServiceController
    {


        //public ActionResult Index()
        //{
        //    return View();
        //}



        // GET: Assignment
        [HttpGet]
        public async Task<ViewResult> Index()
        {

            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Assignment/GetAll");
        
            HttpResponseMessage apiResponse;
            Assignment assignment = new Assignment();
           
            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return View("Error");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }
           
    
            var assignmentAnswer = await apiResponse.Content.ReadAsAsync< List<Assignment>>();
         
            return View( assignmentAnswer);
        }
    }
}