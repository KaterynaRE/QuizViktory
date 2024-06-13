namespace newQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuizResults", "NameCategory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuizResults", "NameCategory");
        }
    }
}
