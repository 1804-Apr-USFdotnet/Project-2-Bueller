﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuellerWebApi.Models
{
    public class Account
    {
        //[Required]
        //public string FirstName { get; set; }
        //[Required]
        //public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}