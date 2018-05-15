using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bueller.DA.Models
{
    [Table("PersonClass", Schema = "Classes")]
    public class PersonClass : BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        //shouldnt ever need to scaffold this table
        public int PersonClassID { get; set; }

        [ForeignKey("Class")]
        [Required]
        public int ClassID1 { get; set; }

        [ForeignKey("Class")]
        public int? ClassID2 { get; set; }

        [ForeignKey("Class")]
        public int? ClassID3 { get; set; }

        [ForeignKey("Class")]
        public int? ClassID4 { get; set; }

        [ForeignKey("Class")]
        public int? ClassID5 { get; set; }

        [ForeignKey("Class")]
        public int? ClassID6 { get; set; }

        [ForeignKey("Class")]
        public int? ClassID7 { get; set; }


        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual Class Class { get; set; }

    }
}
