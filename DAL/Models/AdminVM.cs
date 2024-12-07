
using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class AdminVM : ModelViewBase
    {
       
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Max Length of Name is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Length of Name is 5 Chars")]
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        //[Remote("CheckEmail", controller: "Admin", ErrorMessage = "Email Must Be Unique")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is Required")]
        [MaxLength(20, ErrorMessage = "Max Length of Name is 20 Chars")]
        [MinLength(8, ErrorMessage = "Min Length of Name is 8 Chars")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;


    }
}
