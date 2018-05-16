using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bueller.DA.Models
{
    [Table("Files", Schema = "Assignments")]
    public class File : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [ScaffoldColumn(false)]
        public int FileId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "File name cannot be more than 100 characters")]
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

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
