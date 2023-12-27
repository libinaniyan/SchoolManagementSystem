using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string _password { get; set; }
    }

}