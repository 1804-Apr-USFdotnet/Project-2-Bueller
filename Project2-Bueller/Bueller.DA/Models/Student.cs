using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bueller.DA.Models
{
    [Table("Student", Schema = "Person")]
    public class Student : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name cannot be more than 100 characters")]
        public string FirstName { get; set; }
        [StringLength(100, ErrorMessage = "Middle name cannot be more than 100 characters")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(200, ErrorMessage = "Address cannot be more than 100 characters")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(100, ErrorMessage = "City cannot be more than 100 characters")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        [StringLength(100, ErrorMessage = "State cannot be more than 100 characters")]
        public string State { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [StringLength(100, ErrorMessage = "Country cannot be more than 100 characters")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Zipcode is required")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Invalid input")]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }
        [RegularExpression("[(]{1}[0-9]{3}[)]{1}[ ]{1}[0-9]{3}[-]{1}[0-9]{4}", ErrorMessage = "Format must be (###) ###-####")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        //StudentId int pk
        //firstname nvarchar 100
        //middlename nvarchar 100 nullable
        //lastname nvarchar 100 
        //address1 nvc 200
        //address2 nvc 200 nullable
        //address3 nvc 200 nullable
        //phone tel
        //grade int
        //credits int
        //studenttype nvc 50
        //PersonClassId int fk
        //AccountNumberId int fk

    }
}
