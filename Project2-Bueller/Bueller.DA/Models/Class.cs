using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bueller.DA.Models
{
    [Table("Class", Schema = "Classes")]
    public class Class : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int ClassId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be more than 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Room number is required")]
        [StringLength(20, ErrorMessage = "Room number cannot be more than 100 characters")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Section is required")]
        [StringLength(10, ErrorMessage = "Section cannot be more than 100 characters")]
        public string Section { get; set; }
        [Required(ErrorMessage = "Credits is required")]
        [Range(1, 6, ErrorMessage = "Number of credits must be between 1 and 6")]
        public int Credits { get; set; }

        [Required(ErrorMessage = "Time is required")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        //days similar table to person class

        //no class level for now

        [ForeignKey("Employee")]
        public int TeacherId { get; set; }
        public virtual Employee Teacher { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
