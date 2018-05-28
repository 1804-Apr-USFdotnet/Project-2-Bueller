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


        public AssignmentController()
        {
            ViewBag.Title = "AssignmentController";
        }



        // GET: Assignment
        [HttpGet]
        public async Task<ViewResult> Index(int id)
        {

            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Assignment/GetByClassId/{id}");

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

            List<Assignment> assignments = new List<Assignment>();
            if (apiResponse.IsSuccessStatusCode)
            {
                assignments = await apiResponse.Content.ReadAsAsync<List<Assignment>>();
            }

            ViewBag.classid = id;


            return View(assignments);
        }




        public ViewResult Create(int ClassId)
        {
            Assignment assignment = new Assignment();
            assignment.ClassId = ClassId;



            return View(assignment);

        }
        [HttpPost]
        public async Task<ActionResult> Create(Assignment assignment)
        {

            if (!ModelState.IsValid)
            {
                return View("Error");
            }


            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, $"api/Assignment/Add");
            apiRequest.Content = new ObjectContent<Assignment>(assignment, new JsonMediaTypeFormatter());

            HttpResponseMessage apiResponse;


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



            return RedirectToAction("MyClasses","Class");
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Delete, $"api/Assignment/Delete/{id}");
            HttpResponseMessage apiResponse;

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

            return RedirectToAction("Index");
        }
    }
}

