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
    public class EmployeeAccountDto : BaseEntity
    {
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

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }
    }
}
