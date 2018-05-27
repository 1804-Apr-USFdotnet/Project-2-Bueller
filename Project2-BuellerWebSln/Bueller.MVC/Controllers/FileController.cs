using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bueller.MVC.Controllers
{
    public class FileController : AServiceController
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }
    }
}