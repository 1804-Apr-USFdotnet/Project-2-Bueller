namespace Bueller.DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStudentAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Assignments.Assignments",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        AssignmentName = c.String(nullable: false, maxLength: 100),
                        DueDate = c.DateTime(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("Classes.Classes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
            CreateTable(
                "Classes.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        RoomNumber = c.String(nullable: false, maxLength: 20),
                        Section = c.String(nullable: false, maxLength: 10),
                        Credits = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Mon = c.Int(nullable: false),
                        Tues = c.Int(nullable: false),
                        Wed = c.Int(nullable: false),
                        Thurs = c.Int(nullable: false),
                        Fri = c.Int(nullable: false),
                        TeacherId = c.Int(),
                        SubjectId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("Classes.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("Persons.Employees", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "Persons.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Street = c.String(nullable: false, maxLength: 200),
                        City = c.String(nullable: false, maxLength: 100),
                        State = c.String(nullable: false, maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 100),
                        Zipcode = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Grade = c.String(nullable: false, maxLength: 100),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "Classes.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Department = c.String(nullable: false, maxLength: 100),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "Persons.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        OfficeNumber = c.Int(),
                        FirstName = c.String(nullable: false, maxLength: 200),
                        MiddelName = c.String(maxLength: 200),
                        LastName = c.String(nullable: false, maxLength: 200),
                        Title = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 200),
                        State = c.String(nullable: false, maxLength: 200),
                        Country = c.String(nullable: false, maxLength: 100),
                        Zipcode = c.Int(nullable: false),
                        StreetAddress = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false),
                        PersonalPhoneNumber = c.String(nullable: false),
                        OfficePhoneNumber = c.String(),
                        EmployeeType = c.String(nullable: false, maxLength: 100),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "Assignments.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false, maxLength: 100),
                        AssignmentId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("Assignments.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("Persons.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.AssignmentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "Accounts.EmployeeAccounts",
                c => new
                    {
                        EmployeeAccountId = c.Int(nullable: false, identity: true),
                        PayPeriod = c.String(),
                        Salary = c.Double(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeAccountId)
                .ForeignKey("Persons.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "Assignments.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        EvaluationType = c.String(nullable: false, maxLength: 50),
                        Score = c.Double(nullable: false),
                        GradeLetter = c.String(nullable: false, maxLength: 2),
                        Comment = c.String(maxLength: 500),
                        FileId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("Assignments.Files", t => t.FileId, cascadeDelete: true)
                .Index(t => t.FileId);
            
            CreateTable(
                "Accounts.StudentAccounts",
                c => new
                    {
                        StudentAccountId = c.Int(nullable: false, identity: true),
                        Aid = c.Double(nullable: false),
                        TotalExpense = c.Double(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentAccountId)
                .ForeignKey("Persons.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Class_ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Class_ClassId })
                .ForeignKey("Persons.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("Classes.Classes", t => t.Class_ClassId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Class_ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Accounts.StudentAccounts", "StudentId", "Persons.Students");
            DropForeignKey("Assignments.Grades", "FileId", "Assignments.Files");
            DropForeignKey("Accounts.EmployeeAccounts", "EmployeeId", "Persons.Employees");
            DropForeignKey("Assignments.Files", "StudentId", "Persons.Students");
            DropForeignKey("Assignments.Files", "AssignmentId", "Assignments.Assignments");
            DropForeignKey("Classes.Classes", "TeacherId", "Persons.Employees");
            DropForeignKey("Classes.Classes", "SubjectId", "Classes.Subjects");
            DropForeignKey("dbo.StudentClasses", "Class_ClassId", "Classes.Classes");
            DropForeignKey("dbo.StudentClasses", "Student_StudentId", "Persons.Students");
            DropForeignKey("Assignments.Assignments", "ClassId", "Classes.Classes");
            DropIndex("dbo.StudentClasses", new[] { "Class_ClassId" });
            DropIndex("dbo.StudentClasses", new[] { "Student_StudentId" });
            DropIndex("Accounts.StudentAccounts", new[] { "StudentId" });
            DropIndex("Assignments.Grades", new[] { "FileId" });
            DropIndex("Accounts.EmployeeAccounts", new[] { "EmployeeId" });
            DropIndex("Assignments.Files", new[] { "StudentId" });
            DropIndex("Assignments.Files", new[] { "AssignmentId" });
            DropIndex("Classes.Classes", new[] { "SubjectId" });
            DropIndex("Classes.Classes", new[] { "TeacherId" });
            DropIndex("Assignments.Assignments", new[] { "ClassId" });
            DropTable("dbo.StudentClasses");
            DropTable("Accounts.StudentAccounts");
            DropTable("Assignments.Grades");
            DropTable("Accounts.EmployeeAccounts");
            DropTable("Assignments.Files");
            DropTable("Persons.Employees");
            DropTable("Classes.Subjects");
            DropTable("Persons.Students");
            DropTable("Classes.Classes");
            DropTable("Assignments.Assignments");
        }
    }
}
