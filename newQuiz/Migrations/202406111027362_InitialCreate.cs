namespace newQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerAstronomies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionAstronomyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionAstronomies", t => t.QuestionAstronomyId, cascadeDelete: true)
                .Index(t => t.QuestionAstronomyId);
            
            CreateTable(
                "dbo.QuestionAstronomies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextQ = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCategory = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionBiologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextQ = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.AnswerBiologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionBiologyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionBiologies", t => t.QuestionBiologyId, cascadeDelete: true)
                .Index(t => t.QuestionBiologyId);
            
            CreateTable(
                "dbo.QuestionMixeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextQ = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.AnswerMixeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionMixedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionMixeds", t => t.QuestionMixedId, cascadeDelete: true)
                .Index(t => t.QuestionMixedId);
            
            CreateTable(
                "dbo.QuizResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserRegistrationId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        DateTaken = c.DateTime(nullable: false),
                        CorrectAnswers = c.Int(nullable: false),
                        TotalQuestions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.UserRegistrations", t => t.UserRegistrationId, cascadeDelete: true)
                .Index(t => t.UserRegistrationId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.UserRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PasswordUser = c.String(),
                        LoginUser = c.String(),
                        DateBirthdayUser = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizResults", "UserRegistrationId", "dbo.UserRegistrations");
            DropForeignKey("dbo.QuizResults", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.QuestionMixeds", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AnswerMixeds", "QuestionMixedId", "dbo.QuestionMixeds");
            DropForeignKey("dbo.QuestionBiologies", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AnswerBiologies", "QuestionBiologyId", "dbo.QuestionBiologies");
            DropForeignKey("dbo.QuestionAstronomies", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AnswerAstronomies", "QuestionAstronomyId", "dbo.QuestionAstronomies");
            DropIndex("dbo.QuizResults", new[] { "CategoryId" });
            DropIndex("dbo.QuizResults", new[] { "UserRegistrationId" });
            DropIndex("dbo.AnswerMixeds", new[] { "QuestionMixedId" });
            DropIndex("dbo.QuestionMixeds", new[] { "CategoryId" });
            DropIndex("dbo.AnswerBiologies", new[] { "QuestionBiologyId" });
            DropIndex("dbo.QuestionBiologies", new[] { "CategoryId" });
            DropIndex("dbo.QuestionAstronomies", new[] { "CategoryId" });
            DropIndex("dbo.AnswerAstronomies", new[] { "QuestionAstronomyId" });
            DropTable("dbo.UserRegistrations");
            DropTable("dbo.QuizResults");
            DropTable("dbo.AnswerMixeds");
            DropTable("dbo.QuestionMixeds");
            DropTable("dbo.AnswerBiologies");
            DropTable("dbo.QuestionBiologies");
            DropTable("dbo.Categories");
            DropTable("dbo.QuestionAstronomies");
            DropTable("dbo.AnswerAstronomies");
        }
    }
}
