//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bueller.DA.Models
//{
//     public class UserAccount
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        [ScaffoldColumn(false)]
//        public int UserAccountId{ get; set; }
//        [Required(ErrorMessage = "First name is required")]
//        [DataType(DataType.Text)]
//        [StringLength(100, ErrorMessage = "First name cannot be more than 100 characters")]
//        public string FirstName { get; set; }
//        [Required(ErrorMessage = "Last name is required")]
//        [DataType(DataType.Text)]
//        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters")]
//        public string LastName { get; set; }
//        [Required]
//        [DataType(DataType.EmailAddress)]
//        public string Email { get; set; }
//        [Required]
//        [DataType(DataType.Password)]
//        public string Password { get; set; }
//    }
//}
