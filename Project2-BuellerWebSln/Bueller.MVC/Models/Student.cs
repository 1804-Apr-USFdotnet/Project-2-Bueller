using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bueller.MVC.Models
{
    public class Student
    {
        [ScaffoldColumn(false)]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "First name cannot be more than 100 characters")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Middle Name")]
        [StringLength(100, ErrorMessage = "Middle name cannot be more than 100 characters")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(".{1,200}[@].{1,200}[.].{1,5}", ErrorMessage = "Email is too long, max 200 character on each side of @")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Address cannot be more than 100 characters")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "City cannot be more than 100 characters")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "State cannot be more than 100 characters")]
        public string State { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Country cannot be more than 100 characters")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Zip code is required")]
        [Display(Name = "Zip Code")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Invalid input")]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }
        [RegularExpression("[(]{1}[0-9]{3}[)]{1}[ ]{1}[0-9]{3}[-]{1}[0-9]{4}", ErrorMessage = "Format must be (###) ###-####")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        [Display(Name = "Class Level")]
        [StringLength(100, ErrorMessage = "Grade cannot be more than 100 characters")]
        public string Grade { get; set; }

        //[Required]
        //[ScaffoldColumn(false)]
        //public int StudentAccountId { get; set; }
        //[ForeignKey("StudentAccountId")]
        //public virtual StudentAccount StudentAccount { get; set; }

        //public virtual ICollection<Grade> Grades { get; set; }

        //public virtual ICollection<File> Files { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        //[NotMapped]
        public int Credits
        {
            get
            {
                int a = 0;
                if (this.Classes.Any())
                    foreach (var classitem in Classes)
                    {
                        a += Credits;
                    }

                return a;
            }
        }
        //[NotMapped]
        [Display(Name = "Enrollment Status")]
        public string StudentType {
            get
            {
                if (this.Credits <= 0)
                    return "Not Enrolled";
                if (this.Credits <= 16)
                    return "Part Time";
                return "Full Time";

            }
        }
        //[NotMapped]
        [Display(Name = "Grade")]
        public double AverageGrade { get; set; }
    }
}