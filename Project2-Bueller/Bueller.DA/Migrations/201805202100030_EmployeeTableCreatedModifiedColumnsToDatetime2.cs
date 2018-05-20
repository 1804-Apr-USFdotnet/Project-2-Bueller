namespace Bueller.DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeTableCreatedModifiedColumnsToDatetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Persons.Employees", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Persons.Employees", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("Persons.Employees", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("Persons.Employees", "Created", c => c.DateTime(nullable: false));
        }
    }
}
