using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DAL.Models
{
    public class AssignmentDto : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int AssignmentId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Assignment name cannot be more than 100 characters")]
        public string AssignmentName { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        [Column(TypeName = "datetime2")]
        public DateTime DueDate { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }

        public virtual ICollection<File> Files { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }
    }
}
