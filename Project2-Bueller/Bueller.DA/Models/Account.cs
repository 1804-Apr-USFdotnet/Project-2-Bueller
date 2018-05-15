﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DA.Models
{
    [Table("Account", Schema = "Billing")]
    public class Account : BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int AccountId { get; set; }

 
        public double? BalanceOwed { get; set; }
        public double? Aid { get; set; }
        public double? TotalExpense { get; set; }
        public string PayPeriod { get; set; }
        public double? Salary { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
