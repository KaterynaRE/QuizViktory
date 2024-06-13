namespace newQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PasswordAdmin = c.String(),
                        LoginAdmin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminRegistrations");
        }
    }
}
