using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DA.Models
{
   public  class EmployeePayment : BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int EmployeePaymentId { get; set; }
        [ScaffoldColumn(false)]
        public int EmployeeId { get; set;}
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public double? PaymentAmount { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }

    }
}
