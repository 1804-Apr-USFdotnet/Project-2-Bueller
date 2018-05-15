using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bueller.DA.Models
{
    [Table("Classes", Schema = "Classes")]
    public class Class : BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int ClassId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Name cannot be more than 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Room number is required")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Room number cannot be more than 100 characters")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Section is required")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "Section cannot be more than 100 characters")]
        public string Section { get; set; }
        [Required(ErrorMessage = "Credits is required")]
        [Range(1, 6, ErrorMessage = "Number of credits must be between 1 and 6")]
        public int Credits { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "Room number cannot be more than 100 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Start time is required")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "End time is required")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        //days similar table to person class

        //no class level for now

        [Required]
        [ScaffoldColumn(false)]
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Employee Teacher { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
