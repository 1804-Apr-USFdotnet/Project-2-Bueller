using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bueller.MVC.Models
{
    public class File
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int FileId { get; set; }

        [Required(ErrorMessage = "File name is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "File name cannot be more than 100 characters")]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        //[DataType(DataType.Upload)]     //not sure about this annotation
        //public string FileLocation { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int AssignmentId { get; set; }
        [ForeignKey("AssignmentId")]
        public virtual Assignment Assignment { get; set; }

        //[Required]
        //[ScaffoldColumn(false)]
        //public int GradeId { get; set; }
        //[ForeignKey("GradeId")]
        //public virtual Grade Grade { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }
    }
}