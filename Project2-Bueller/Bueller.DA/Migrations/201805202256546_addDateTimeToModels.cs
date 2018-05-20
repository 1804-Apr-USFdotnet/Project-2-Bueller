namespace Bueller.DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateTimeToModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Assignments.Assignments", "DueDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Assignments.Assignments", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Assignments.Assignments", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Classes.Classes", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Classes.Classes", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Persons.Students", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Persons.Students", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Classes.Subjects", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Classes.Subjects", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Assignments.Files", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Assignments.Files", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Accounts.EmployeeAccounts", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Accounts.EmployeeAccounts", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Assignments.Grades", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Assignments.Grades", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Accounts.StudentAccounts", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("Accounts.StudentAccounts", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("Accounts.StudentAccounts", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("Accounts.StudentAccounts", "Created", c => c.DateTime(nullable: false));
            AlterColumn("Assignments.Grades", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("Assignments.Grades", "Created", c => c.DateTime(nullable: false));
            AlterColumn("Accounts.EmployeeAccounts", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("Accounts.EmployeeAccounts", "Created", c => c.DateTime(nullable: false));
            AlterColumn("Assignments.Files", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("Assignments.Files", "Created", c => c.DateTime(nullable: false));
            AlterColumn("Classes.Subjects", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("Classes.Subjects", "Created", c => c.DateTime(nullable: false));
            AlterColumn("Persons.Students", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("Persons.Students", "Created", c => c.DateTime(nullable: false));
            AlterColumn("Classes.Classes", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("Classes.Classes", "Created", c => c.DateTime(nullable: false));
            AlterColumn("Assignments.Assignments", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("Assignments.Assignments", "Created", c => c.DateTime(nullable: false));
            AlterColumn("Assignments.Assignments", "DueDate", c => c.DateTime(nullable: false));
        }
    }
}
