namespace newQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuizResults", "LoginUser_Id", "dbo.UserRegistrations");
            DropIndex("dbo.QuizResults", new[] { "LoginUser_Id" });
            AddColumn("dbo.QuizResults", "LoginUser", c => c.String());
            DropColumn("dbo.QuizResults", "LoginUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuizResults", "LoginUser_Id", c => c.Int());
            DropColumn("dbo.QuizResults", "LoginUser");
            CreateIndex("dbo.QuizResults", "LoginUser_Id");
            AddForeignKey("dbo.QuizResults", "LoginUser_Id", "dbo.UserRegistrations", "Id");
        }
    }
}
