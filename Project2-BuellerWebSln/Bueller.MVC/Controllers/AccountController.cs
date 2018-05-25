using System;
using System.Collections;
using System.Collections.Generic;
using System.EnterpriseServices;
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
                return RedirectToAction("RegisterStudentInfo", "Account", new { email = account.Email });
            }
            else
            {
                //return RedirectToAction("RegisterEmployeeInfo", "Account", new { email = account.Email});//or email
                return RedirectToAction("RegisterEmployeeInfo", "Account", new { email = account.Email, type = role });//or email
            }
        }

        public ActionResult RegisterStudentInfo(string email)
        {
            return View();
        }

        [Route("RegisterEmployeeInfo")]
        public ActionResult RegisterEmployeeInfo(string email, string type)
        {
            ViewBag.Type = type;
            TempData["Role"] = type;
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

        //middle name doesn't map...
        //add employee type auto-fill...?
        [HttpPost]
        public async Task<ActionResult> RegisterEmployeeInfo(Employee employee)
        {
            string role = (string)TempData.Peek("Role");
            if (role == "teacher")
            {
                employee.EmployeeType = "teacher";
            }

            //doesn't work with teacher role for some reason.. passes server side check and creates employee model successfully though
            //if (!ModelState.IsValid)
            //{
            //    //Console.WriteLine(  ModelState.Values);
            //    //IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            //    TempData["Error"] = ModelState;
            //    //Console.Read();
            //    //ViewBag.State = ModelState;
            //    return View("Error");
            //}

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


            HttpCookie userEmailCookie = new HttpCookie("userEmailCookie");
            userEmailCookie.Value = account.Email;

            Response.Cookies.Add(userEmailCookie);

            await AddEmployeeCookie(account.Email);

            PassCookiesToClient(apiResponse);



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


            if (Request.Cookies["userEmailCookie"] != null)
            {
                var c = new HttpCookie("userEmailCookie");
                var c2 = new HttpCookie("EmployeeId");
                c2.Expires = DateTime.Now.AddDays(-1);
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c2);
                Response.Cookies.Add(c);
            }

            PassCookiesToClient(apiResponse);
            return RedirectToAction("Index", "Home");
        }

        public async Task AddEmployeeCookie(string email)
        {

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, $"api/Employee/GetByEmail/{email}/");

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
            PassCookiesToClient(apiResponse);

            var employee = await apiResponse.Content.ReadAsAsync<Employee>();
            HttpCookie employeeIdCookie = new HttpCookie("EmployeeId");
            employeeIdCookie.Value = employee.EmployeeID.ToString();

            Response.Cookies.Add(employeeIdCookie);


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