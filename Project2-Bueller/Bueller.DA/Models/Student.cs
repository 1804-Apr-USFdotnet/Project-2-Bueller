using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bueller.DA.Models
{
    [Table("Students", Schema = "Persons")]
    public class Student : BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "First name cannot be more than 100 characters")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Middle name cannot be more than 100 characters")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Address cannot be more than 100 characters")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "City cannot be more than 100 characters")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "State cannot be more than 100 characters")]
        public string State { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Country cannot be more than 100 characters")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Zipcode is required")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Invalid input")]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }
        [RegularExpression("[(]{1}[0-9]{3}[)]{1}[ ]{1}[0-9]{3}[-]{1}[0-9]{4}", ErrorMessage = "Format must be (###) ###-####")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        [StringLength(100, ErrorMessage = "Grade cannot be more than 100 characters")]
        public string Grade { get; set; }

        //public int? PersonClassId { get; set; }
        //public virtual PersonClass PersonClass { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual StudentAccount Account { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        [NotMapped]
        public int Credits { get; set; }
        [NotMapped]
        public string StudentType { get; set; }
        [NotMapped]
        public double AverageGrade { get; set; }
    }
}
