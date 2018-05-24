using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bueller.MVC.Models
{
    public class Assignment
    {

        public int AssignmentId { get; set; }

        // this will also be title of homework assignment
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Assignment name cannot be more than 100 characters")]
        [Display(Name =" Assignment Title")]
        public string AssignmentName { get; set; }

        [Required(ErrorMessage = "Due date is required")]

        public DateTime DueDate { get; set; }

        //[Required]
        //[DataType(DataType.Upload)]     //not sure about this annotation
        //public HttpPostedFileBase AssignmentUpload { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public IEnumerable<SelectListItem> AvailableClasses { get; set; }


        public DateTime Created { get; set; }
       
        public DateTime Modified { get; set; }
    }
}