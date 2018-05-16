using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DA.Models
{
    [Table("Assignments", Schema = "Assignments")]
    public  class Assignment : BaseEntity
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int AssignmentId { get; set; }

        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }


        // this will also be title of homework assignment
        [Required]
        [DataType(DataType.Text)]
        public string FileName { get; set; }

        [Required]
        [DataType(DataType.Upload)]     //not sure about this annotation
        public string FileLocation { get; set; }

        public DateTime DueDate { get; set; }


        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
