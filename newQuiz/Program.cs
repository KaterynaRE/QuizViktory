using newQuiz.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace newQuiz
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.InputEncoding = Encoding.UTF8;
			Console.OutputEncoding = Encoding.UTF8;
			Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA");
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA");


			Console.WriteLine("1 - Admin\t2 - User\tE - вихід");
			string choiceFirst = Console.ReadLine();
			switch (choiceFirst)
			{
				case "1":
					Console.WriteLine("1 - Реєстрація\t\t2 - Вхід");
					string choiceRegistrationNewAdmin = Console.ReadLine().ToUpper();

					AdminRegistrationClass admin = new AdminRegistrationClass();
					if (choiceRegistrationNewAdmin == "1")
					{
						admin.RegistrationLogInAdmin();
						admin.AdminDifference.MenuAdmin(admin);
					}
					else if (choiceRegistrationNewAdmin == "2")
					{
						admin.LogInAdmin();
						admin.AdminDifference.MenuAdmin(admin);
					}                   
                    break;
				case "2":
					Console.WriteLine("1 - Реєстрація\t\t2 - Вхід");
					string choiceRegistrationOrLogin = Console.ReadLine();

					UserRegistrationClass user = new UserRegistrationClass();
					if (choiceRegistrationOrLogin == "1")
					{
						user.RegistrationLogIn();
						user.UserDifference.MenuUser(user);
					}
					else if (choiceRegistrationOrLogin == "2")
					{
						user.LogIn();
						user.UserDifference.MenuUser(user);
					}
					break;
				case "E":
					return;
				default:
					break;
			}



			using (QuizContext db = new QuizContext())
			{
				//Category category = new Category();
				//category.Id = 1;
				//category.NameCategory = "Biology";
				//db.Categories.Add(category);
				//db.SaveChanges();

				//Category categoryA = new Category();
				//categoryA.Id = 2;
				//categoryA.NameCategory = "Astronomy";
				//db.Categories.Add(categoryA);
				//db.SaveChanges();

				//Category categoryM = new Category();
				//categoryM.Id = 3;
				//categoryM.NameCategory = "Mixed";
				//db.Categories.Add(categoryM);
				//db.SaveChanges();


				//var biologyCategory = db.Categories.FirstOrDefault(c => c.NameCategory == "Biology");
				//if (biologyCategory == null)
				//{
				//	Console.WriteLine("Category 'Biology' not found.");
				//	return;
				//}

				//////додавання нових питань
				//QuestionBiologyClass questionB = new QuestionBiologyClass();
				//var questionsB = questionB.QuestionBiology();

				//foreach (var text in questionsB)
				//{
				//	var question = new QuestionBiology
				//	{
				//		TextQ = text,
				//		CategoryId = biologyCategory.Id
				//	};
				//	db.QuestionBiologys.Add(question);
				//}
				//db.SaveChanges();

				//Console.WriteLine("All questions have been added.");


				// Додавання нових відповідей

				//void AddAnswer(int questionId, string text, bool isCorrect)
				//{
				//	var answer = new AnswerBiology
				//	{
				//		Text = text,
				//		IsCorrect = isCorrect,
				//		QuestionBiologyId = questionId
				//	};
				//	db.AnswerBiologys.Add(answer);
				//}

				//var answers = new List<(int questionId, string text, bool isCorrect)>
				//	{
				//	(21, "A", false),
				//	(21, "B", true),
				//	(21, "C", false),
				//	(22, "A", false),
				//	(22, "B", true),
				//	(22, "C", false),
				//	(23, "A", true),
				//	(23, "B", false),
				//	(23, "C", false),
				//	(24, "A", false),
				//	(24, "B", true),
				//	(24, "C", false),
				//	(25, "A", false),
				//	(25, "B", false),
				//	(25, "C", true),
				//	(26, "A", true),
				//	(26, "B", false),
				//	(26, "C", false),
				//	(27, "A", false),
				//	(27, "B", true),
				//	(27, "C", false),
				//	(28, "A", false),
				//	(28, "B", true),
				//	(28, "C", false),
				//	(29, "A", false),
				//	(29, "B", false),
				//	(29, "C", true),
				//	(30, "A", false),
				//	(30, "B", false),
				//	(30, "C", true),
				//	(31, "A", false),
				//	(31, "B", true),
				//	(31, "C", false),
				//	(32, "A", false),
				//	(32, "B", false),
				//	(32, "C", true),
				//	(33, "A", true),
				//	(33, "B", false),
				//	(33, "C", false),
				//	(34, "A", true),
				//	(34, "B", false),
				//	(34, "C", false),
				//	(35, "A", false),
				//	(35, "B", true),
				//	(35, "C", false),
				//	(36, "A", false),
				//	(36, "B", true),
				//	(36, "C", false),
				//	(37, "A", true),
				//	(37, "B", false),
				//	(37, "C", false),
				//	(38, "A", true),
				//	(38, "B", false),
				//	(38, "C", false),
				//	(39, "A", false),
				//	(39, "B", true),
				//	(39, "C", false),
				//	(40, "A", false),
				//	(40, "B", true),
				//	(40, "C", false),
				//};

				//foreach (var (questionId, text, isCorrect) in answers)
				//{
				//	AddAnswer(questionId, text, isCorrect);
				//}
				//db.SaveChanges();


				//astronomy

				//var astronomyCategory = db.Categories.FirstOrDefault(c => c.NameCategory == "Astronomy");
				//if (astronomyCategory == null)
				//{
				//	Console.WriteLine("Category 'Astronomy' not found.");
				//	return;
				//}

				//////додавання нових питань
				//QuestionAstronomyClass questionA = new QuestionAstronomyClass();
				//var questionsA = questionA.QuestionAstronomy();

				//foreach (var text in questionsA)
				//{
				//	var question = new QuestionAstronomy
				//	{
				//		TextQ = text,
				//		CategoryId = astronomyCategory.Id
				//	};
				//	db.QuestionAstronomys.Add(question);
				//}
				//db.SaveChanges();

				//Console.WriteLine("All questions have been added.");


				// Додавання нових відповідей astr

				//void AddAnswer(int questionId, string text, bool isCorrect)
				//{
				//	var answer = new AnswerAstronomy
				//	{
				//		Text = text,
				//		IsCorrect = isCorrect,
				//		QuestionAstronomyId = questionId
				//	};
				//	db.AnswerAstronomys.Add(answer);
				//}

				//var answers = new List<(int questionId, string text, bool isCorrect)>
				//{
				//	(21, "A", false),
				//	(21, "B", true),
				//	(21, "C", false),
				//	(22, "A", true),
				//	(22, "B", false),
				//	(22, "C", false),
				//	(23, "A", false),
				//	(23, "B", false),
				//	(23, "C", true),
				//	(24, "A", false),
				//	(24, "B", true),
				//	(24, "C", false),
				//	(25, "A", true),
				//	(25, "B", false),
				//	(25, "C", false),
				//	(26, "A", false),
				//	(26, "B", false),
				//	(26, "C", true),
				//	(27, "A", false),
				//	(27, "B", true),
				//	(27, "C", false),
				//	(28, "A", true),
				//	(28, "B", false),
				//	(28, "C", false),
				//	(29, "A", false),
				//	(29, "B", false),
				//	(29, "C", true),
				//	(30, "A", false),
				//	(30, "B", true),
				//	(30, "C", false),
				//	(31, "A", true),
				//	(31, "B", false),
				//	(31, "C", false),
				//	(32, "A", false),
				//	(32, "B", false),
				//	(32, "C", true),
				//	(33, "A", false),
				//	(33, "B", true),
				//	(33, "C", false),
				//	(34, "A", true),
				//	(34, "B", false),
				//	(34, "C", false),
				//	(35, "A", false),
				//	(35, "B", false),
				//	(35, "C", true),
				//	(36, "A", false),
				//	(36, "B", true),
				//	(36, "C", false),
				//	(37, "A", true),
				//	(37, "B", false),
				//	(37, "C", false),
				//	(38, "A", false),
				//	(38, "B", false),
				//	(38, "C", true),
				//	(39, "A", false),
				//	(39, "B", true),
				//	(39, "C", false),
				//	(40, "A", true),
				//	(40, "B", false),
				//	(40, "C", false)
				//};

				//foreach (var (questionId, text, isCorrect) in answers)
				//{
				//	AddAnswer(questionId, text, isCorrect);
				//}
				//db.SaveChanges();



			}
		}
	}
}
