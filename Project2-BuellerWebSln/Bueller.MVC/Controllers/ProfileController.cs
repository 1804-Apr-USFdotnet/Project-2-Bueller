using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bueller.MVC.Models;

namespace Bueller.MVC.Controllers
{
    public class ProfileController : AServiceController
    {
        // GET: Profile
        public async Task<ActionResult> Index()
        {
            var role = Request.Cookies["Role"].Value;
            
            if (role == "teacher" || role == "employee")
            {
                //Employee emp = await apiResponse.Content.ReadAsAsync<Employee>();
                return RedirectToAction("Employee");
            }
            if (role == "student")
            {
                //Student stu = await apiResponse.Content.ReadAsAsync<Student>();
                return RedirectToAction("Student");
            }

            return View("Error");
        }

        // GET: Profile/Details/5
        public async Task<ActionResult> Employee()
        {
            var role = Request.Cookies["Role"].Value;

            if (role != "teacher" && role != "employee")
            {
                return View("Error");
            }

            var id = Request.Cookies["Id"].Value;

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Employee/GetById/{id}");
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

            Employee emp = await apiResponse.Content.ReadAsAsync<Employee>();

            if (emp == null)
                return View("Error");

            return View(emp);
        }

        // GET: Profile/Details/5
        public async Task<ActionResult> Student()
        {
            var role = Request.Cookies["Role"].Value;

            if (role != "student")
            {
                return View("Error");
            }

            var id = Request.Cookies["Id"].Value;

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Student/GetById/{id}");
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

            Student stu = await apiResponse.Content.ReadAsAsync<Student>();

            if (stu == null)
                return View("Error");

            return View(stu);
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
