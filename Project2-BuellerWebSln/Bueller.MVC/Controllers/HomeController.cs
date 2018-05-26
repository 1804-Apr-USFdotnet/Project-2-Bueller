using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bueller.MVC.Models;

namespace Bueller.MVC.Controllers
{
    public class HomeController : AServiceController
    {
        public async Task<ActionResult> Index()
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Account/GetLoginInfo");
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
                if (apiResponse.StatusCode != HttpStatusCode.Unauthorized)
                {
                    return View("Error");
                }
                ViewBag.Message = "Not logged in!";
            }
            else
            {
                var contentString = await apiResponse.Content.ReadAsStringAsync();

                //string role = contentString.Substring(contentString.IndexOf(":") + 3, contentString.LastIndexOf("]"));
                string role = contentString.Substring(contentString.IndexOf(":") + 2).TrimEnd('"');
                ViewBag.Message = "Logged in! Result: " + contentString + "\n" + role;



                var cookie = Request.Cookies.Get("userEmailCookie");
                if (cookie != null)
                {
                    string email = cookie.Value;
                    await AddCookie(email, role);
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task AddCookie(string email, string role)
        {

            //HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Employee/GetByEmail/{email}/");
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Account/GetAccount/{email}/{role}");

            HttpResponseMessage apiResponse;
            Assignment assignment = new Assignment();

            //try
            //{
            apiResponse = await HttpClient.SendAsync(apiRequest);
            //}
            //catch
            //{

            //}

            //if (!apiResponse.IsSuccessStatusCode)
            //{

            // }
            //PassCookiesToClient(apiResponse);

            HttpCookie Id = new HttpCookie("Id");
            if (role == "teacher" || role == "employee")
            {
                var employee = await apiResponse.Content.ReadAsAsync<Employee>();

                Id.Value = employee.EmployeeID.ToString();
            }
            else if (role == "student")
            {
                var employee = await apiResponse.Content.ReadAsAsync<Student>();

                Id.Value = employee.StudentId.ToString();
            }

            Response.Cookies.Add(Id);

            HttpCookie Role = new HttpCookie("Role");
            Role.Value = role;
            Response.Cookies.Add(Role);

        }
    }
}