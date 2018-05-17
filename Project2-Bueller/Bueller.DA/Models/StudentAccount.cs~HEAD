using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DA.Models
{
    [Table("Accounts", Schema = "Billing")]
    public class StudentAccount : BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int AccountId { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }


        [DataType(DataType.Currency)]
        public double? BalanceOwed { get; set; }

        [DataType(DataType.Currency)]
        public double? Aid { get; set; }

        // This should  probably  be a computed column 
        [DataType(DataType.Currency)]
        public double? TotalExpense { get; set; }

        //weekly, bi-weekly, monthly
        public string PayPeriod { get; set; }

        [DataType(DataType.Currency)]
        public double? Salary { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
