
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    [Table("Qualifications")]
    public class QualificationModel
    {
        [Key]
        public int QualificationId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Course Name is required.")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Percentage is required.")]
        public decimal Percentage { get; set; }
        [Required(ErrorMessage = "Year of Passing is required.")]
        public int YearOfPassing { get; set; }
        public virtual StudentModel Student { get; set; }

    }
}