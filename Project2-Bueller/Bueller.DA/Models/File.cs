using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bueller.DA.Models
{
    [Table("Files", Schema = "Submit")]
    public class File : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [ScaffoldColumn(false)]
        public int FileID { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int TeacherID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FileName { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public string FileLocation { get; set; }

        public virtual Student Student { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
