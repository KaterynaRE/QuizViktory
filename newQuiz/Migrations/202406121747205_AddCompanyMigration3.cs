namespace newQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.QuizResults", "NameCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuizResults", "NameCategory", c => c.String());
        }
    }
}
