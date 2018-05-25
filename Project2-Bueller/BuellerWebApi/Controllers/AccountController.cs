using Bueller.DA;
using BuellerWebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Bueller.DAL.Repos;
using Microsoft.Ajax.Utilities;


namespace BuellerWebApi.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly UnitOfWork unit = new UnitOfWork();
        private StudentRepo studentRepo;
        private EmployeeRepo employeeRepo;

        public AccountController()
        {
            studentRepo = unit.StudentRepo();
            employeeRepo = unit.EmployeeRepo();
        }

        //[HttpPost]
        //[Route("Register")]
        //[AllowAnonymous]
        //public IHttpActionResult Register(Account account)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // actually register
        //    var userStore = new UserStore<IdentityUser>(new IdentityContext());
        //    var userManager = new UserManager<IdentityUser>(userStore);
        //    var user = new IdentityUser(account.Email);

        //    if (userManager.Users.Any(u => u.UserName == account.Email))
        //    {
        //        return BadRequest();
        //    }

        //    userManager.Create(user, account.Password);


        //    return Ok();
        //}

        [HttpPost]
        [Route("RegisterRole/{role}")]
        [AllowAnonymous]
        public IHttpActionResult RegisterWithRoles(Account account, string role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!role.Equals("student") && !role.Equals("teacher") && !role.Equals("employee"))
            {
                return BadRequest(role);
            }

            // actually register
            var userStore = new UserStore<IdentityUser>(new IdentityContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = new IdentityUser(account.Email);

            if (userManager.Users.Any(u => u.UserName == account.Email))
            {
                return BadRequest();
            }

            userManager.Create(user, account.Password);

            // the only difference from Register 
            userManager.AddClaim(user.Id, new Claim(ClaimTypes.Role, role));

            //login
            var authManager = Request.GetOwinContext().Authentication;
            var claimsIdentity = userManager.CreateIdentity(user, WebApiConfig.AuthenticationType);

            authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claimsIdentity);

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IHttpActionResult LogIn(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // actually login
            var userStore = new UserStore<IdentityUser>(new IdentityContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Users.FirstOrDefault(u => u.UserName == account.Email);


            if (user == null)
            {
                return BadRequest();
            }

            if (!userManager.CheckPassword(user, account.Password))
            {
                return Unauthorized();
            }

            var authManager = Request.GetOwinContext().Authentication;
            var claimsIdentity = userManager.CreateIdentity(user, WebApiConfig.AuthenticationType);

            authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claimsIdentity);

            return Ok();
        }

        [HttpGet]
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut(WebApiConfig.AuthenticationType);
            return Ok();
        }


        //in uri have email and type of account to look for (student/employee)
        [HttpGet]
        [Route("GetAccount/{email}/{type}")]
        public IHttpActionResult GetAccountByEmail(string email, string type)
        {
            dynamic account;
            bool match = false;
            if (type.Equals("employee"))
            {
                account = employeeRepo.Table.FirstOrDefault(x => x.Email.Equals(email));
                match = true;
                if (account != null)
                {
                    return Ok(account);
                }
            }

            if (type.Equals("student"))
            {
                account = studentRepo.Table.FirstOrDefault(x => x.Email.Equals(email));
                match = true;
                if (account != null)
                {
                    return Ok(account);
                }
            }

            if (match)
            {
                return Content(HttpStatusCode.NotFound, "Email does not exist");
            }

            return BadRequest();
        }
    }
}
