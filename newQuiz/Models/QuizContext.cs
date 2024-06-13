using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Models
{
	internal class QuizContext: DbContext

	{
		public QuizContext() : base("QuizDB") { }

		public DbSet<AdminRegistration> AdminRegistrations { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<AnswerAstronomy> AnswerAstronomys { get; set; }
		public DbSet<AnswerBiology> AnswerBiologys { get; set; }
		public DbSet<AnswerMixed> AnswerMixes { get; set; }
		public DbSet<QuestionAstronomy> QuestionAstronomys { get; set; }
		public DbSet<QuestionBiology> QuestionBiologys { get; set; }
		public DbSet<QuestionMixed> QuestionMixes { get; set; }
		public DbSet<UserRegistration> UserRegistrations { get; set; }
		public DbSet<QuizResult> QuizResults { get; set; }
		public DbSet<QuestionNew> QuestionNews {  get; set; }
		public DbSet<AnswerNew> AnswerNews { get; set; }
	}
}
