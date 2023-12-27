﻿namespace SchoolManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatatypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "PhoneNumber", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
