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
        public int FileID { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int StudentID { get; set; }
        

        // Not really required if we work with assignment class
        [Required]
        [ScaffoldColumn(false)]
        public int ClassID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FileName { get; set; }

        [Required]
        [DataType(DataType.Upload)]     //not sure about this annotation
        public string FileLocation { get; set; }

        // Not really required if we work with assignment class
        public DateTime DueDate { get; set; }


        [ForeignKey("AssignmentID")]
        public virtual Assignment Assignment { get; set; }


        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
