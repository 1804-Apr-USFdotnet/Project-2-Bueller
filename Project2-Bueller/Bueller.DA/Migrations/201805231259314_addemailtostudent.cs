namespace Bueller.DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemailtostudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("Persons.Students", "Email", c => c.String(nullable: false));
            AddColumn("Persons.Employees", "MiddleName", c => c.String(maxLength: 200));
            DropColumn("Persons.Employees", "MiddelName");
        }
        
        public override void Down()
        {
            AddColumn("Persons.Employees", "MiddelName", c => c.String(maxLength: 200));
            DropColumn("Persons.Employees", "MiddleName");
            DropColumn("Persons.Students", "Email");
        }
    }
}
