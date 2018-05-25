using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Bueller.MVC.Controllers
{
    public class AServiceController : Controller
    {
        protected static readonly HttpClient HttpClient = new HttpClient(new HttpClientHandler() {UseCookies = false});
        private static readonly Uri serviceUri = new Uri("http://localhost:57265/");
        private static readonly string cookieName = "AuthTestCookie";
        private static readonly string cookieName2 = "TeacherId";

        // GET: AService
        //public ActionResult Index()
        //{
        //    return View();
        //}

        protected HttpRequestMessage CreateRequestToService(HttpMethod method, string uri)
        {
            var apiRequest = new HttpRequestMessage(method, new Uri(serviceUri, uri));
            string cookieValue = Request.Cookies[cookieName]?.Value ?? "";
            string cookieValue2 = Request.Cookies[cookieName2]?.Value ?? "";
            apiRequest.Headers.Add("Cookie", new CookieHeaderValue(cookieName, cookieValue).ToString());
            apiRequest.Headers.Add("Cookie2", new CookieHeaderValue(cookieName2, cookieValue2).ToString());
            return apiRequest;
        }
    }
}