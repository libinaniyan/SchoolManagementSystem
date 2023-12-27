namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        QualificationId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseName = c.String(nullable: false),
                        Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YearOfPassing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QualificationId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 25),
                        LastName = c.String(maxLength: 25),
                        Age = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        PhoneNumber = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 20),
                        _password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qualifications", "StudentId", "dbo.Students");
            DropIndex("dbo.Qualifications", new[] { "StudentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Qualifications");
        }
    }
}
