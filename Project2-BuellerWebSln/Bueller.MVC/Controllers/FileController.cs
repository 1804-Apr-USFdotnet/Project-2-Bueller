﻿using Bueller.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bueller.MVC.Controllers
{
    public class FileController : AServiceController
    {

        //public async Task<ActionResult> Index()
        //{
        //    HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/File/GetAll");
        //    HttpResponseMessage apiResponse;

        //    try
        //    {
        //        apiResponse = await HttpClient.SendAsync(apiRequest);
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }

        //    List<File> files = new List<File>();
        //    if (apiResponse.IsSuccessStatusCode)
        //    {
        //        files = await apiResponse.Content.ReadAsAsync<List<File>>();
        //    }



        //    return View(files);
        //}

        //public async Task<ActionResult> GetByIdClass(int classId)
        //{
        //    if (classId == 0)
        //    {
        //        return View("Error");
        //    }

        //    HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/File/GetByClassId/{classId}");
        //    HttpResponseMessage apiResponse;

        //    try
        //    {
        //        apiResponse = await HttpClient.SendAsync(apiRequest);
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }

        //    List<File> files = new List<File>();
        //    if (apiResponse.IsSuccessStatusCode)
        //    {
        //        files = await apiResponse.Content.ReadAsAsync<List<File>>();
        //    }


        //    return View(files);
        //}

        public async Task<ActionResult> GetByIdAssignment(int id)
        {
            if (id == 0)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/File/GetByAssignmentId/{id}");
            HttpResponseMessage apiResponse;

            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return View("Error");
            }

            List<File> files = new List<File>();
            if (apiResponse.IsSuccessStatusCode)
            {
                files = await apiResponse.Content.ReadAsAsync<List<File>>();
            }


            return View(files);
        }

        public async Task<ActionResult> GetByIdStudent(int studentId, int assignmentId)
        {
            if (studentId == 0 || assignmentId == 0)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/File/GetByAsnIdAndStudentId/{studentId}/{assignmentId}");
            HttpResponseMessage apiResponse;

            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return View("Error");
            }

            List<File> files = new List<File>();
            if (apiResponse.IsSuccessStatusCode)
            {
                files = await apiResponse.Content.ReadAsAsync<List<File>>();
            }


            return View(files);
        }


        public ActionResult AddFile(int AssignmentId, int StudentId)
        {
            if (Request.Cookies["Role"].Value != "student")
            {
                return View("Error");
            }

            if (StudentId != Convert.ToInt32(Request.Cookies["Id"].Value))
            {
                return View("Error");
            }

            File file = new File();
            file.AssignmentId = AssignmentId;
            file.StudentId = StudentId;
            return View(file);
        }

        [HttpPost]
        public async Task<ActionResult> AddFile(File file)
        {
            if (Request.Cookies["Role"].Value != "student")
            {
                return View("Error");
            }

            if (file.StudentId != Convert.ToInt32(Request.Cookies["Id"].Value))
            {
                return View("Error");
            }

            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, $"api/File/Add");
            apiRequest.Content = new ObjectContent<File>(file, new JsonMediaTypeFormatter());

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

            return RedirectToAction("MyClasses", "Class");
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return View("Error");
            }

            if (Request.Cookies["Role"].Value != "student")
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/File/GetById/{id}");
            HttpResponseMessage apiResponse;

            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return View("Error");
            }

            File file = new File();
            if (apiResponse.IsSuccessStatusCode)
            {
                file = await apiResponse.Content.ReadAsAsync<File>();
            }

            if (file.StudentId != Convert.ToInt32(Request.Cookies["Id"].Value))
            {
                return View("Error");
            }

            return View(file);
        }


        [HttpPost]
        public async Task<ActionResult> Edit(int id, File file)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            if (Request.Cookies["Role"].Value != "student")
            {
                return View("Error");
            }

            if (file.StudentId != Convert.ToInt32(Request.Cookies["Id"].Value))
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Put, $"api/File/AddAt/{id}");
            apiRequest.Content = new ObjectContent<File>(file, new JsonMediaTypeFormatter());

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

            return RedirectToAction("MyClasses", "Class");

        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return View("Error");
            }

            if (Request.Cookies["Role"].Value != "student")
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/File/GetById/{id}");
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

            var file = await apiResponse.Content.ReadAsAsync<File>();

            if (file.StudentId != Convert.ToInt32(Request.Cookies["Id"].Value))
            {
                return View("Error");
            }

            return View(file);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Delete, $"api/File/Delete/{id}");
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

            return RedirectToAction("MyClasses", "Class");
        }

        //[HttpGet]
        //public async Task<ActionResult> Details(int id)
        //{
        //    HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/File/GetById/{id}");
        //    HttpResponseMessage apiResponse;

        //    try
        //    {
        //        apiResponse = await HttpClient.SendAsync(apiRequest);
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }

        //    File file = new File();
        //    if (apiResponse.IsSuccessStatusCode)
        //    {
        //        file = await apiResponse.Content.ReadAsAsync<File>();
        //    }

        //    return View(file);
        //}
    }
}