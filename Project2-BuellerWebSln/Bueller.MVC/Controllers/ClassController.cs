using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bueller.MVC.Models;

namespace Bueller.MVC.Controllers
{
    public class ClassController : AServiceController
    {
        //add instructor name to view for students? or withhold if teacher logged in...
        //add enrollment count too?
        //have create/edit/delete only show up for teachers
        //details view for description and link to textbook purchase?

        // GET: Assignment
        [HttpGet]
        public async Task<ViewResult> Index()
        {

            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Class/GetAll");

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


            var classes = await apiResponse.Content.ReadAsAsync<List<Class>>();

            return View(classes);
        }
    }
}