using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DA.Models
{
    public class Subject : BaseEntity
    {

        public int SubjectId { get; set; }
        [Required]
        public string  Name { get; set; }
        public byte Credits { get; set; }
        public string Department { get; set; }
    }
}
