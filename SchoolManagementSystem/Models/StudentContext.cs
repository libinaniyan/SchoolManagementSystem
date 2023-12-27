using System.Data.Entity;

namespace SchoolManagementSystem.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext() : base("dbconnection")
        {

        }
        public DbSet<StudentModel> Students { get; set; }

        public DbSet<QualificationModel> QualificationModels { get; set; }
       
    }
}