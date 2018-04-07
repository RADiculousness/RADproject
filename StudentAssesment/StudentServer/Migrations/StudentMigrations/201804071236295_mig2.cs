namespace StudentServer.Migrations.StudentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentGrades",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        ModuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.ModuleID })
                .ForeignKey("dbo.Modules", t => t.ModuleID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.ModuleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGrades", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentGrades", "ModuleID", "dbo.Modules");
            DropIndex("dbo.StudentGrades", new[] { "ModuleID" });
            DropIndex("dbo.StudentGrades", new[] { "StudentID" });
            DropTable("dbo.StudentGrades");
        }
    }
}
