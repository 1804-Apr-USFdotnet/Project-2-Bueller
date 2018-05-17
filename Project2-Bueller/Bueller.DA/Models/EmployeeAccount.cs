using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DA.Models
{
    [Table("EmployeeAccounts", Schema = "Accounts")]
    public class EmployeeAccount : BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int EmployeeAccountId { get; set; }

        //weekly, bi-weekly, monthly
        public string PayPeriod { get; set; }

        [DataType(DataType.Currency)]
        public double Salary { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
