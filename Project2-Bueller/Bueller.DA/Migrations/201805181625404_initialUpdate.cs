namespace Bueller.DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Classes.Classes", "TeacherId", "Persons.Employees");
            DropIndex("Classes.Classes", new[] { "TeacherId" });
            AlterColumn("Classes.Classes", "TeacherId", c => c.Int());
            CreateIndex("Classes.Classes", "TeacherId");
            AddForeignKey("Classes.Classes", "TeacherId", "Persons.Employees", "EmployeeID");
        }
        
        public override void Down()
        {
            DropForeignKey("Classes.Classes", "TeacherId", "Persons.Employees");
            DropIndex("Classes.Classes", new[] { "TeacherId" });
            AlterColumn("Classes.Classes", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("Classes.Classes", "TeacherId");
            AddForeignKey("Classes.Classes", "TeacherId", "Persons.Employees", "EmployeeID", cascadeDelete: true);
        }
    }
}
