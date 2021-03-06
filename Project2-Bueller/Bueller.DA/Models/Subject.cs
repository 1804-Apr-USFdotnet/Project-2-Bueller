﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bueller.DA.Models
{
    [Table("Subjects", Schema = "Classes")]
    public class Subject : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int SubjectId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Name cannot be longer than {1} characters")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Department cannot be longer than {1} characters")]
        public string Department { get; set; }

        //credits is part of class model

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }
    }
}
