namespace newQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuizResults", "LoginUser_Id", c => c.Int());
            CreateIndex("dbo.QuizResults", "LoginUser_Id");
            AddForeignKey("dbo.QuizResults", "LoginUser_Id", "dbo.UserRegistrations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizResults", "LoginUser_Id", "dbo.UserRegistrations");
            DropIndex("dbo.QuizResults", new[] { "LoginUser_Id" });
            DropColumn("dbo.QuizResults", "LoginUser_Id");
        }
    }
}
