using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    [Table("Students")]
    public class StudentModel
    {
        // Validations already handled by jQuery
        [Key]
        public int StudentId { get; set; }
        //[Required(ErrorMessage = "First name is required.")]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
        //[Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        //[Required(ErrorMessage = "Gender is required.")]
        [MaxLength(20)]
        public string Gender { get; set; }
        //[Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(50)]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Phone number is required.")]
        [Range(6000000000, 9999999999, ErrorMessage = "Phone number must be between 6000000000 and 9999999999.")]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public List<QualificationModel> Qualifications { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(20)]
        public string Username { get; set; }
        [DisplayName("Password")]
        [MinLength(5)]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string _password { get; set; }      
    }
   

}