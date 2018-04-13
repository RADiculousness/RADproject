namespace StudentServer.Migrations.StudentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Login : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logins");
        }
    }
}
