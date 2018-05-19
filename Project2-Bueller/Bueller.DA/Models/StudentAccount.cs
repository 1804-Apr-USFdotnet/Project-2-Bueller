using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DA.Models
{
    [Table("StudentAccounts", Schema = "Accounts")]
    public class StudentAccount : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int StudentAccountId { get; set; }
 
        [DataType(DataType.Currency)]
        public double BalanceOwed { get; set; }

        [DataType(DataType.Currency)]
        public double Aid { get; set; }

        [DataType(DataType.Currency)]
        public double TotalExpense { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
