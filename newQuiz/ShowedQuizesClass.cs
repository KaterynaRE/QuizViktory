using newQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Helper
{
	internal class ShowedQuizesClass
	{
		public static void ShowQuizAstronomy(AdminRegistrationClass loginAdmin, QuizContext context)
		{
			var admin = context.AdminRegistrations.FirstOrDefault(a => a.LoginAdmin == loginAdmin.Login && a.PasswordAdmin == loginAdmin.Password);

			if (admin != null)
			{
				var category = context.Categories.FirstOrDefault(c => c.NameCategory == "Astronomy");

				if (category != null)
				{
					var questions = context.QuestionAstronomys.Where(q => q.CategoryId == category.Id).ToList();

					if (questions.Any())
					{
						Console.WriteLine($"Питання для категорії '{category.NameCategory}':");

						foreach (var question in questions)
						{
							Console.WriteLine($"- {question.TextQ}");
						}
					}
					else
					{
						Console.WriteLine("У цій категорії немає питань.");
					}
				}
				else
				{
					Console.WriteLine("Категорію не знайдено.");
				}
			}
			else
			{
				Console.WriteLine("Ви не маєте доступу до цієї інформації");
			}
		}

		public static void ShowQuizBiology(AdminRegistrationClass loginAdmin, QuizContext context)
		{
			var admin = context.AdminRegistrations.FirstOrDefault(a => a.LoginAdmin == loginAdmin.Login && a.PasswordAdmin == loginAdmin.Password);

			if (admin != null)
			{
				var category = context.Categories.FirstOrDefault(c => c.NameCategory == "Biology");

				if (category != null)
				{
					var questions = context.QuestionBiologys.Where(q => q.CategoryId == category.Id).ToList();

					if (questions.Any())
					{
						Console.WriteLine($"Питання для категорії '{category.NameCategory}':");

						foreach (var question in questions)
						{
							Console.WriteLine($"- {question.TextQ}");
						}
					}
					else
					{
						Console.WriteLine("У цій категорії немає питань.");
					}
				}
				else
				{
					Console.WriteLine("Категорію не знайдено.");
				}
			}
			else
			{
				Console.WriteLine("Ви не маєте доступу до цієї інформації");
			}
		}

		public static void SomeQuizWithQuestionNew(AdminRegistrationClass loginAdmin, QuizContext context)
		{
			Console.WriteLine("Введіть назву вікторини щоб отримати питання:");
			string nameV = Console.ReadLine().ToUpper();

			var admin = context.AdminRegistrations.FirstOrDefault(a => a.LoginAdmin == loginAdmin.Login && a.PasswordAdmin == loginAdmin.Password);

			if (admin != null)
			{
				var category = context.Categories.FirstOrDefault(c => c.NameCategory.ToUpper() == nameV);

				if (category != null)
				{
					var questions = context.QuestionNews.Where(q => q.CategoryId == category.Id).ToList();

					if (questions.Any())
					{
						Console.WriteLine($"Питання для категорії '{category.NameCategory}':");

						foreach (var question in questions)
						{
							Console.WriteLine($"- {question.TextQ}");
						}
					}
					else
					{
						Console.WriteLine("У цій категорії немає питань.");
					}
				}
				else
				{
					Console.WriteLine("Категорію не знайдено.");
				}
			}
			else
			{
				Console.WriteLine("Ви не маєте доступу до цієї інформації");
			}
		}
	}
}
