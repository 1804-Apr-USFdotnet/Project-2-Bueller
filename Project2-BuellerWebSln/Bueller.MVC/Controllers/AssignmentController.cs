﻿using System;
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
           
    
            var assignments = await apiResponse.Content.ReadAsAsync< List<Assignment>>();
         
            return View( assignments);
        }



          public async Task<ViewResult> Create()
        {

            var email = this.Session["Email"];

            Class  classObj= new Class();
            Assignment assignment = new Assignment();
           
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Class/GetByTeacherEmail/{email}");

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
            List<string> classNames = new List<string>();
            foreach (var item in classes)
            {
                classNames.Add(item.Name);
            }
            assignment.AvailableClasses = new SelectList(classNames);


            return View(assignment);

        }
        [HttpPost]
        public async Task<ActionResult> Create( Assignment assignment)
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

            

            return RedirectToAction("Index");
        }
    }
}
