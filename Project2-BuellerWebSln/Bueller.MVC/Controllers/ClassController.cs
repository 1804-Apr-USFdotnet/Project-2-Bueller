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
        //details view for description and link to textbook purchase? subject and class level?

        // GET: Classes
        [HttpGet]
        public async Task<ViewResult> Index()
        {

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Class/GetAll");
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

            var classes = await apiResponse.Content.ReadAsAsync<List<Class>>();

            return View(classes);
        }


        [HttpGet]
        public async Task<ViewResult> TeacherClasses()
        {

            var teacherId = Request.Cookies["EmployeeId"].Value;

            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Class/GetByTeacherId/{teacherId}/");

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

        // GET: Classes
        [HttpGet]
        public async Task<ViewResult> Details(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Class/GetById/{id}");

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

            var classresponse = await apiResponse.Content.ReadAsAsync<Class>();

            return View(classresponse);
        }


        //right now subject id entered manually
        public ActionResult Create()
        {
            //Assignment assignment = new Assignment();
            //assignment.ClassId = ClassId;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Class newClass)
        {
            if (Request.Cookies.Get("Role").Value == "teacher")
            {
                newClass.TeacherId = Convert.ToInt32(Request.Cookies.Get("Id").Value);
            }

            if (!ModelState.IsValid)
            {
                return View("Error");
            }


            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, $"api/Class/Add");
            apiRequest.Content = new ObjectContent<Class>(newClass, new JsonMediaTypeFormatter());

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