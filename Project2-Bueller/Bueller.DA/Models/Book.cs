using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DA.Models
{
   public  class Book : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int BookId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Book name cannot be more than 100 characters")]
        public string BookTitle { get; set; }

        //[DataType(DataType.Upload)]     //not sure about this annotation
        //public string FileLocation { get; set; }

        [Required]
        public decimal Price { get; set; }

        //[Required]
        //[ScaffoldColumn(false)]
        //public int GradeId { get; set; }
        //[ForeignKey("GradeId")]
        //public virtual Grade Grade { get; set; }

        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }
    }
}
