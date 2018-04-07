namespace StudentServer.Migrations.StudentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAttendances",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        attended = c.Boolean(nullable: false),
                        AttendanceOf_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Attendances", t => t.AttendanceOf_id)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.AttendanceOf_id);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        AttDate = c.DateTime(nullable: false),
                        ForDelivery_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Lectures", t => t.ForDelivery_id)
                .Index(t => t.ForDelivery_id);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        TimeSlot = c.Time(nullable: false, precision: 7),
                        ModuleId = c.Int(nullable: false),
                        LecturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Lecturers", t => t.LecturerId, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.LecturerId);
            
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RegistrationID = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAttendances", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Attendances", "ForDelivery_id", "dbo.Lectures");
            DropForeignKey("dbo.Lectures", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Lectures", "LecturerId", "dbo.Lecturers");
            DropForeignKey("dbo.StudentAttendances", "AttendanceOf_id", "dbo.Attendances");
            DropIndex("dbo.Enrollments", new[] { "ModuleId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Lectures", new[] { "LecturerId" });
            DropIndex("dbo.Lectures", new[] { "ModuleId" });
            DropIndex("dbo.Attendances", new[] { "ForDelivery_id" });
            DropIndex("dbo.StudentAttendances", new[] { "AttendanceOf_id" });
            DropIndex("dbo.StudentAttendances", new[] { "StudentID" });
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Modules");
            DropTable("dbo.Lecturers");
            DropTable("dbo.Lectures");
            DropTable("dbo.Attendances");
            DropTable("dbo.StudentAttendances");
        }
    }
}
