namespace newQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionNewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionNews", t => t.QuestionNewId, cascadeDelete: true)
                .Index(t => t.QuestionNewId);
            
            CreateTable(
                "dbo.QuestionNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextQ = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionNews", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AnswerNews", "QuestionNewId", "dbo.QuestionNews");
            DropIndex("dbo.QuestionNews", new[] { "CategoryId" });
            DropIndex("dbo.AnswerNews", new[] { "QuestionNewId" });
            DropTable("dbo.QuestionNews");
            DropTable("dbo.AnswerNews");
        }
    }
}
