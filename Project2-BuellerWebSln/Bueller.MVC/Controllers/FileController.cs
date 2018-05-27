using Bueller.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bueller.MVC.Controllers
{
    public class FileController : AServiceController
    {
        [HttpGet]
        public async Task<ViewResult> Index(int id)
        {

            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/File/GetByClassId/{id}");

            HttpResponseMessage apiResponse;
            File assignment = new File();

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


            var assignments = await apiResponse.Content.ReadAsAsync<List<File>>();

            return View(assignments);
        }
    }
}