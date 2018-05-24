using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bueller.MVC.Models;
using Microsoft.Ajax.Utilities;

namespace Bueller.MVC.Controllers
{
    public class AccountController : AServiceController
    {
        public ActionResult Register()
        {
            return View();
        }

        //create new model account too depending on role
        //pass in email to register info view
        //ability to delete user accounts...
        //prevent register/additional login once logged in... important? and hide logout when not logged in?...
        [HttpPost]
        public async Task<ActionResult> Register(Account account, string role)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, $"api/Account/RegisterRole/{role}");
            apiRequest.Content = new ObjectContent<Account>(account, new JsonMediaTypeFormatter());

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

            PassCookiesToClient(apiResponse);

            if (role == "student")
            {
                return RedirectToAction("RegisterStudentInfo", "Account", new {email = account.Email});
            }
            else 
            {
                return RedirectToAction("RegisterEmployeeInfo", "Account", new { email = account.Email });//or email
            }
        }

        public ActionResult RegisterStudentInfo(string email)
        {
            //return View(email);
            //ViewBag.Title = "RegisterStudentInfo";
            //ViewBag.Email = email;
            return View();
        }

        [Route("RegisterEmployeeInfo/{role}")]
        public ActionResult RegisterEmployeeInfo(string email)
        {
            //ViewBag.Email = email;
            return View();
        }

        //prevent registering account only and backing out of creating corresponding model...
        // change register/login steps?
        //tie in account to person models
        //unathorized problem
        //1.  login on server side with register
        //2.  redirect to login action following register. but how to redirect where to go after login (home or enter info)... 
        //    way to keep track of how got to login action? straight from home or from register
        [HttpPost]
        public async Task<ActionResult> RegisterStudentInfo(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, $"api/Student");
            apiRequest.Content = new ObjectContent<Student>(student, new JsonMediaTypeFormatter());

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

            PassCookiesToClient(apiResponse);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> RegisterEmployeeInfo(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, $"api/Employee/Add");
            apiRequest.Content = new ObjectContent<Employee>(employee, new JsonMediaTypeFormatter());

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

            PassCookiesToClient(apiResponse);

            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public async Task<ActionResult> Login(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/Account/Login");
            apiRequest.Content = new ObjectContent<Account>(account, new JsonMediaTypeFormatter());

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

            PassCookiesToClient(apiResponse);
            this.Session["Email"] = account.Email;

            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Logout
        public async Task<ActionResult> Logout()
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Account/Logout");

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

            PassCookiesToClient(apiResponse);

            return RedirectToAction("Index", "Home");
        }

        private bool PassCookiesToClient(HttpResponseMessage apiResponse)
        {
            if (apiResponse.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values))
            {
                foreach (string value in values)
                {
                    Response.Headers.Add("Set-Cookie", value);
                }
                return true;
            }
            return false;
        }
    }
}