﻿//using Bueller.DA;
//using BuellerWebApi.Models;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.Owin.Security;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Security.Claims;
//using System.Web.Http;

//namespace BuellerWebApi.Controllers
//{
//    public class AccountController : ApiController
//    {


//        [HttpPost]
//        [Route("~/api/Account/Register")]
//        [AllowAnonymous]
//        public IHttpActionResult Register(Account account)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest();
//            }

//            // actually register
//            var userStore = new UserStore<IdentityUser>(new BuellerContext());
//            var userManager = new UserManager<IdentityUser>(userStore);
//            var user = new IdentityUser(account.UserName);

//            if (userManager.Users.Any(u => u.UserName == account.UserName))
//            {
//                return BadRequest();
//            }

//            userManager.Create(user, account.Password);

//            return Ok();
//        }

//        [HttpPost]
//        [Route("~/api/Account/RegisterAdmin")]
//        [AllowAnonymous]
//        public IHttpActionResult RegisterAdmin(Account account)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest();
//            }

//            // actually register
//            var userStore = new UserStore<IdentityUser>(new BuellerContext());
//            var userManager = new UserManager<IdentityUser>(userStore);
//            var user = new IdentityUser(account.UserName);

//            if (userManager.Users.Any(u => u.UserName == account.UserName))
//            {
//                return BadRequest();
//            }

//            userManager.Create(user, account.Password);

//            // the only difference from Register action
//            userManager.AddClaim(user.Id, new Claim(ClaimTypes.Role, "admin"));

//            return Ok();
//        }

//        [HttpPost]
//        [Route("~/api/Account/Login")]
//        [AllowAnonymous]
//        public IHttpActionResult LogIn(Account account)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest();
//            }

//            // actually login
//            var userStore = new UserStore<IdentityUser>(new BuellerContext());
//            var userManager = new UserManager<IdentityUser>(userStore);
//            var user = userManager.Users.FirstOrDefault(u => u.UserName == account.UserName);


//            if (user == null)
//            {
//                return BadRequest();
//            }

//            if (!userManager.CheckPassword(user, account.Password))
//            {
//                return Unauthorized();
//            }

//            var authManager = Request.GetOwinContext().Authentication;
//            var claimsIdentity = userManager.CreateIdentity(user, "ApplicationCookie");

//            authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claimsIdentity);

//            return Ok();
//        }

//        [HttpGet]
//        [Route("~/api/Account/Logout")]
//        public IHttpActionResult Logout()
//        {
//            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
//            return Ok();
//        }
//    }
//}
