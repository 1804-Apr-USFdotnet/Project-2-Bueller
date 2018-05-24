using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bueller.MVC.Models
{
    public class Employee
    {
        [ScaffoldColumn(false)]
        public int EmployeeID { get; set; }

        [Display(Name = "Office Number")]
        public int? OfficeNumber { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [StringLength(200, ErrorMessage = "Name must be shorter than {1} characters")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Middle Name")]
        [StringLength(200, ErrorMessage = "Name must be shorter than {1} charcters")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [StringLength(200, ErrorMessage = "Name must be shorter than {1} characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Title must be shorter than {1} characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "City is required")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "City must be shorter than {1} characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "State must be shorter than {1} characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Country must be shorter than {1} characters")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Zip code is required")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zip code must be 5 digits")]
        public int Zipcode { get; set; }

        [Required(ErrorMessage = "Street address is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Street Address")]
        [StringLength(200, ErrorMessage = "Street address must be shorter than {1} characters")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(".{1,200}[@].{1,200}[.].{1,5}", ErrorMessage = "Email is too long, max 200 character on each side of @")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Personal phone number is required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Personal Phone Number")]
        [RegularExpression("[(]{1}[0-9]{3}[)]{1}[ ]{1}[0-9]{3}[-]{1}[0-9]{4}", ErrorMessage = "Format must be (###) ###-####")]
        public string PersonalPhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Office Phone Number")]
        [RegularExpression("[(]{1}[0-9]{3}[)]{1}[ ]{1}[0-9]{3}[-]{1}[0-9]{4}", ErrorMessage = "Format must be (###) ###-####")]
        public string OfficePhoneNumber { get; set; }

        [Required(ErrorMessage = "Employee type is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Employee Type")]
        [StringLength(100, ErrorMessage = "Employee type must be shorter than {1} characters")]
        public string EmployeeType { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        //public virtual ICollection<Class> Classes { get; set; }
    }
}