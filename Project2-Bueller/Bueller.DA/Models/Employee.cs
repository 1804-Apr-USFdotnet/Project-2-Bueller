using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bueller.DA.Models
{
    [Table("Employees", Schema = "Persons")]
    public class Employee : BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int EmployeeID { get; set; }

        [ForeignKey("PersonClass")]
        [ScaffoldColumn(false)]
        public int? PersonClassID { get; set; }

        public int? OfficeNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Name must be shorter than {1} characters")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Name must be shorter than {1} charcters")]
        public string MiddelName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Name must be shorter than {1} characters")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Title must be shorter than {1} characters")]
        public string Title { get; set; }

        [Required]
        [ForeignKey("Account")]
        [ScaffoldColumn(false)]
        public int AccountNumberID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "City must be shorter than {1} characters")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "State must be shorter than {1} characters")]
        public string State { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Country must be shorter than {1} characters")]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zipcode must be 5 digits")]
        public int Zipcode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Street address must be shorter than {1} characters")]
        public string StreetAddress { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(".{1,200}[@].{1,200}[.].{1,5}",ErrorMessage = "Email is too long, max 200 character on each side of @")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("[(]{1}[0-9]{3}[)]{1}[ ]{1}[0-9]{3}[-]{1}[0-9]{4}", ErrorMessage = "Format must be (###) ###-####")]
        public string PersonalPhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression("[(]{1}[0-9]{3}[)]{1}[ ]{1}[0-9]{3}[-]{1}[0-9]{4}", ErrorMessage = "Format must be (###) ###-####")]
        public string OfficePhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Employee type must be shorter than {1} characters")]
        public string EmployeeType { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }


        public virtual PersonClass PersonClass { get; set; }
        public virtual Account Account { get; set; }
    }
}
