using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuellerWebApi.Models
{
    public class Assignment : BaseEntity
    {

        public int AssignmentId { get; set; }


        public string AssignmentName { get; set; }


        public DateTime DueDate { get; set; }

        //[Required]
        //[DataType(DataType.Upload)]     //not sure about this annotation
        //public HttpPostedFileBase AssignmentUpload { get; set; }

   
        public int ClassId { get; set; }

        //public virtual Class Class { get; set; }

        //public virtual ICollection<File> Files { get; set; }
    }
}