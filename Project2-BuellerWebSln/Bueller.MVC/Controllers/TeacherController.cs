﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bueller.MVC.Models;

namespace Bueller.MVC.Controllers
{
    public class TeacherController : AServiceController
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetStudents()
        {
            int id = Convert.ToInt32(Request.Cookies["Id"].Value);

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Employee/GetStudentsByTeacherId/{id}");
            HttpResponseMessage apiResponse;

            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return View("Error");
            }

            List<Student> files = new List<Student>();
            if (apiResponse.IsSuccessStatusCode)
            {
                files = await apiResponse.Content.ReadAsAsync<List<Student>>();
            }


            return View(files);
        }
    }
}