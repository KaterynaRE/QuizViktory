using newQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using newQuiz.Helper;

namespace newQuiz
{
	internal class AdminDiferenseCass
	{
		public void MenuAdmin(AdminRegistrationClass loginAdmin)
		{
			QuizContext context = new QuizContext();
			while (true)
			{
				Console.WriteLine("\nОберіть розділ:");
				Console.WriteLine("1 Створити нову вікторину");
				Console.WriteLine("2 Видалити вікторину");
				Console.WriteLine("3 Переглянути усіх користувачів");
				Console.WriteLine("4 Переглянути існуючі вікторини");
				Console.WriteLine("5 Переглянути вибрану вікторину з питаннями");
				Console.WriteLine("6 Вихід");

				string choiceRozdil = Console.ReadLine();

				switch (choiceRozdil)
				{
					case "1":
						CreateNewVitorin(loginAdmin, context);
						break;
					case "2":
						DeleteVitorin(loginAdmin, context);
						break;
					case "3":
						AllUsersWillBeReviewed(loginAdmin, context);
						break;
					case "4":
						AllQuizToBe(loginAdmin, context);
						break;
					case "5":
						ShowQuizVithQuestion(loginAdmin);
						break;
					case "6":
						return; 
					default:
						Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
						break;
				}
			}
		}

		public void ShowQuizVithQuestion(AdminRegistrationClass loginAdmin)
		{
			QuizContext context = new QuizContext();
			while (true)
			{
				Console.WriteLine("\nОберіть розділ:");
				Console.WriteLine("1 Відкрити вікторину з 'Біології'");
				Console.WriteLine("2 Відкрити вікторину з 'Астрономії'");
				Console.WriteLine("3 Знайти вікторину по назві");
				Console.WriteLine("4 Вихід");

				string choiceRozdil = Console.ReadLine();

				switch (choiceRozdil)
				{
					case "1":
						ShowedQuizesClass.ShowQuizBiology(loginAdmin, context);
						break;
					case "2":
						ShowedQuizesClass.ShowQuizAstronomy(loginAdmin, context);
						break;
					case "3":
						ShowedQuizesClass.SomeQuizWithQuestionNew(loginAdmin, context);
						break;
					case "4":
						return;
					default:
						Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
						break;
				}
			}
		}

		public void CreateNewVitorin(AdminRegistrationClass loginAdmin, QuizContext context)
		{

			Console.WriteLine("1 - Додати нову категорію");
			Console.WriteLine("2 - Додати питання до категорії");
			Console.WriteLine("3 - Додати відповіді до категорії");
			Console.WriteLine("e - назад");
			string choiceCreateV = Console.ReadLine().ToLower();
			switch (choiceCreateV)
			{
				case "1":
					AddViktorineOtherClass1.CreateCategory();
					break;
				case "2":
					AddViktorineOtherClass1.CreateQuestionForCategory();
					break;
				case "3":
					AddViktorineOtherClass1.CreateAnswerForQuestion();
					break;
				case "e":
					return;
				default:
					break;
			}
		}

		public void DeleteVitorin(AdminRegistrationClass loginAdmin, QuizContext context)
		{

			Console.WriteLine("1 - Видалити вікторину");
			Console.WriteLine("2 - Видалити питання до вікторини");
			Console.WriteLine("3 - Видалити відповіді до вікторини");
			Console.WriteLine("4 - Видалити вікторину з Біології");
			Console.WriteLine("5 - Видалити вікторину з Aстрономії");
			Console.WriteLine("e - назад");
			string choiceCreateV = Console.ReadLine();
			switch (choiceCreateV)
			{
				case "1":
					DeletingViktoryneOtherClass1.DeleteViktorineC();
					break;
				case "2":
					DeletingViktoryneOtherClass1.DeleteQuestionNew();
					break;
				case "3":
					DeletingViktoryneOtherClass1.DeleteAnswerNew();
					break;
				case "4":
					DeletingViktoryneOtherClass1.DeleteViktorineBiology();
					break;
				case "5":
					DeletingViktoryneOtherClass1.DeleteViktorineAstronomy();
					break;
				default:
					break;
			}
		}

		public void AllQuizToBe(AdminRegistrationClass loginAdmin, QuizContext context)
		{
			var allViktorine = context.Categories
			   .OrderBy(c => c.Id)
			   .ToList();

			var admin = context.AdminRegistrations.FirstOrDefault(a => a.LoginAdmin == loginAdmin.Login && a.PasswordAdmin == loginAdmin.Password);

			if (admin != null)
			{
				foreach (var viktory in allViktorine)
				{
					Console.WriteLine($"Category Id: {viktory.Id}\nName category: {viktory.NameCategory} ");
				}
			}
			else
			{
				Console.WriteLine("Ви не маєте доступу до цієї інформації");
			}
		}
		public void AllUsersWillBeReviewed(AdminRegistrationClass loginAdmin, QuizContext context)
		{
			var results = context.UserRegistrations
			   .OrderBy(u => u.Id)
			   .ToList();

			var admin = context.AdminRegistrations.FirstOrDefault(a => a.LoginAdmin == loginAdmin.Login && a.PasswordAdmin == loginAdmin.Password);

			if (admin != null)
			{
				foreach (var user in results)
				{
					Console.WriteLine($"User: {user.Id},\nLogin: {user.LoginUser}, Date of Birth: {user.DateBirthdayUser}");
				}
			}
			else
			{
				Console.WriteLine("Ви не маєте доступу до цієї інформації");
			}
		}















		//public void ShowQuizAstronomy(AdminRegistrationClass loginAdmin, QuizContext context)
		//{
		//	var admin = context.AdminRegistrations.FirstOrDefault(a => a.LoginAdmin == loginAdmin.Login && a.PasswordAdmin == loginAdmin.Password);

		//	if (admin != null)
		//	{
		//		var category = context.Categories.FirstOrDefault(c => c.NameCategory == "Astronomy");

		//		if (category != null)
		//		{
		//			var questions = context.QuestionAstronomys.Where(q => q.CategoryId == category.Id).ToList();

		//			if (questions.Any())
		//			{
		//				Console.WriteLine($"Питання для категорії '{category.NameCategory}':");

		//				foreach (var question in questions)
		//				{
		//					Console.WriteLine($"- {question.TextQ}");
		//				}
		//			}
		//			else
		//			{
		//				Console.WriteLine("У цій категорії немає питань.");
		//			}
		//		}
		//		else
		//		{
		//			Console.WriteLine("Категорію не знайдено.");
		//		}
		//	}
		//	else
		//	{
		//		Console.WriteLine("Ви не маєте доступу до цієї інформації");
		//	}
		//}

		//public void ShowQuizBiology(AdminRegistrationClass loginAdmin, QuizContext context)
		//{
		//	var admin = context.AdminRegistrations.FirstOrDefault(a => a.LoginAdmin == loginAdmin.Login && a.PasswordAdmin == loginAdmin.Password);

		//	if (admin != null)
		//	{
		//		var category = context.Categories.FirstOrDefault(c => c.NameCategory == "Biology");

		//		if (category != null)
		//		{
		//			var questions = context.QuestionBiologys.Where(q => q.CategoryId == category.Id).ToList();

		//			if (questions.Any())
		//			{
		//				Console.WriteLine($"Питання для категорії '{category.NameCategory}':");

		//				foreach (var question in questions)
		//				{
		//					Console.WriteLine($"- {question.TextQ}");
		//				}
		//			}
		//			else
		//			{
		//				Console.WriteLine("У цій категорії немає питань.");
		//			}
		//		}
		//		else
		//		{
		//			Console.WriteLine("Категорію не знайдено.");
		//		}
		//	}
		//	else
		//	{
		//		Console.WriteLine("Ви не маєте доступу до цієї інформації");
		//	}
		//}

		//public void SomeQuizWithQuestionNew(AdminRegistrationClass loginAdmin, QuizContext context)
		//{
		//	Console.WriteLine("Введіть назву вікторини щоб отримати питання:");
		//	string nameV = Console.ReadLine().ToUpper();

		//	var admin = context.AdminRegistrations.FirstOrDefault(a => a.LoginAdmin == loginAdmin.Login && a.PasswordAdmin == loginAdmin.Password);

		//	if (admin != null)
		//	{
		//		var category = context.Categories.FirstOrDefault(c => c.NameCategory.ToUpper() == nameV);

		//		if (category != null)
		//		{
		//			var questions = context.QuestionNews.Where(q => q.CategoryId == category.Id).ToList();

		//			if (questions.Any())
		//			{
		//				Console.WriteLine($"Питання для категорії '{category.NameCategory}':");

		//				foreach (var question in questions)
		//				{
		//					Console.WriteLine($"- {question.TextQ}");
		//				}
		//			}
		//			else
		//			{
		//				Console.WriteLine("У цій категорії немає питань.");
		//			}
		//		}
		//		else
		//		{
		//			Console.WriteLine("Категорію не знайдено.");
		//		}
		//	}
		//	else
		//	{
		//		Console.WriteLine("Ви не маєте доступу до цієї інформації");
		//	}
		//}


		//public void CreateCategory()
		//{
		//	Console.WriteLine("Введіть Id нової вікторини:");
		//	int IdV = int.Parse(Console.ReadLine());

		//	using (QuizContext db = new QuizContext())
		//	{
		//		// перевіряємо чи вільний Id
		//		var existingCategory = db.Categories.FirstOrDefault(c => c.Id == IdV);
		//		if (existingCategory != null)
		//		{
		//			Console.WriteLine("Категорія з таким Id вже існує. Введіть інший Id.");
		//			return;
		//		}

		//		Console.WriteLine("Введіть назву категорії для нової вікторини: ");
		//		string nameViktorineNew = Console.ReadLine().ToUpper();

		//		var existingName = db.Categories.FirstOrDefault(c => c.NameCategory.ToUpper() == nameViktorineNew);
		//		if (existingName != null)
		//		{
		//			Console.WriteLine("Категорія з таким ім'ям вже існує. Введіть іншу назву.");
		//			return;
		//		}

		//		// створюємо і додаємо нову категорію
		//		Category category = new Category
		//		{
		//			Id = IdV,
		//			NameCategory = nameViktorineNew
		//		};
		//		db.Categories.Add(category);
		//		db.SaveChanges();
		//		Console.WriteLine("Категорію збережено.");
		//	}
		//}

		//public void CreateQuestionForCategory()
		//{
		//	Console.WriteLine("Введіть назву категорії куди треба додати питання");
		//	string nameNewViktorin = Console.ReadLine().ToUpper();

		//	using (QuizContext db = new QuizContext())
		//	{
		//		var categoryAddQuestion = db.Categories.FirstOrDefault(c => c.NameCategory.ToUpper() == nameNewViktorin);
		//		if (categoryAddQuestion == null)
		//		{
		//			Console.WriteLine("Категорію не знайдено.");
		//			return;
		//		}
		//		while (true)
		//		{
		//			Console.WriteLine("Введіть текст питання (або 'e' для виходу):");
		//			string questionText = Console.ReadLine();
		//			if (questionText.ToLower() == "e")
		//			{
		//				break;
		//			}

		//			QuestionNew question = new QuestionNew
		//			{
		//				TextQ = questionText,
		//				CategoryId = categoryAddQuestion.Id
		//			};

		//			db.QuestionNews.Add(question);
		//			db.SaveChanges();
		//			Console.WriteLine("Питання додано.");

		//			Console.WriteLine("Чи хочете додати ще одне питання? (y/n):");
		//			string addAnother = Console.ReadLine().ToLower();
		//			if (addAnother.ToLower() != "y")
		//			{
		//				break;
		//			}
		//		}
		//	}
		//}

		//public void CreateAnswerForQuestion()
		//{
		//	Console.WriteLine("Введіть питання для додавання відповіді:");
		//	string nameQuestion = Console.ReadLine().ToUpper();

		//	using (QuizContext db = new QuizContext())
		//	{
		//		var questionAddAnswer = db.QuestionNews.FirstOrDefault(c => c.TextQ.ToUpper() == nameQuestion);
		//		if (questionAddAnswer == null)
		//		{
		//			Console.WriteLine("Питання не знайдено.");
		//			return;
		//		}

		//		int correctAnswers = 0;
		//		int incorrectAnswers = 0;

		//		while (true)
		//		{
		//			if (correctAnswers == 1 && incorrectAnswers == 2)
		//			{
		//				Console.WriteLine("Додано достатню кількість відповідей для цього питання.");
		//				break;
		//			}

		//			Console.WriteLine("Додайте відповідь (або 'e' для виходу):");
		//			string answerText = Console.ReadLine();
		//			if (answerText.ToLower() == "e")
		//			{
		//				break;
		//			}

		//			Console.WriteLine("Чи це вірна відповідь? (t - так, f - ні):");
		//			string check = Console.ReadLine().ToLower();
		//			bool isCorrect;

		//			if (check == "t")
		//			{
		//				if (correctAnswers == 1)
		//				{
		//					Console.WriteLine("Вже додано одну вірну відповідь. Ви не можете додати більше.");
		//					continue;
		//				}
		//				isCorrect = true;
		//				correctAnswers++;
		//			}
		//			else if (check == "f")
		//			{
		//				if (incorrectAnswers == 2)
		//				{
		//					Console.WriteLine("Вже додано дві невірні відповіді. Ви не можете додати більше.");
		//					continue;
		//				}
		//				isCorrect = false;
		//				incorrectAnswers++;
		//			}
		//			else
		//			{
		//				Console.WriteLine("Некоректний вибір. Будь ласка, введіть 't' або 'f'.");
		//				continue;
		//			}

		//			AnswerNew answer = new AnswerNew
		//			{
		//				Text = answerText,
		//				IsCorrect = isCorrect,
		//				QuestionNewId = questionAddAnswer.Id
		//			};

		//			db.AnswerNews.Add(answer);
		//			db.SaveChanges();
		//			Console.WriteLine("Відповідь додано.");

		//			if (correctAnswers == 1 && incorrectAnswers == 2)
		//			{
		//				Console.WriteLine("Додано достатню кількість відповідей для цього питання.");
		//				break;
		//			}

		//			Console.WriteLine("Чи хочете додати ще одну відповідь? (y/n):");
		//			string addAnother = Console.ReadLine().ToLower();
		//			if (addAnother != "y")
		//			{
		//				break;
		//			}
		//		}
		//	}
		//}



		//public void DeleteViktorineC()
		//{
		//	Console.WriteLine("Введіть назву вікторини для видалення:");
		//	string nameC = Console.ReadLine().ToLower();

		//	using (QuizContext db = new QuizContext())
		//	{
		//		var delCat = db.Categories.FirstOrDefault(c => c.NameCategory.ToLower() == nameC);

		//		if (delCat == null)
		//		{
		//			Console.WriteLine("Категорію не знайдено.");
		//			return;
		//		}

		//		try
		//		{
		//			// Знаходимо всі питання, пов'язані з категорією
		//			var questions = db.QuestionNews.Where(q => q.CategoryId == delCat.Id).ToList();

		//			// Для кожного питання знаходимо і видаляємо пов'язані відповіді
		//			foreach (var question in questions)
		//			{
		//				var answers = db.AnswerNews.Where(a => a.QuestionNewId == question.Id).ToList();
		//				db.AnswerNews.RemoveRange(answers);
		//			}

		//			// Видаляємо всі питання, пов'язані з категорією
		//			db.QuestionNews.RemoveRange(questions);

		//			// Видаляємо категорію
		//			db.Categories.Remove(delCat);
		//			db.SaveChanges();
		//			Console.WriteLine("Категорію та всі пов'язані питання і відповіді видалено.");
		//		}
		//		catch (Exception ex)
		//		{
		//			Console.WriteLine("Виникла помилка під час видалення категорії: " + ex.Message);
		//		}
		//	}
		//}

		//public void DeleteQuestionNew()
		//{
		//	Console.WriteLine("Введіть назву категорії для видалення питання:");
		//	string nameC = Console.ReadLine().ToLower();

		//	using (QuizContext db = new QuizContext())
		//	{
		//		var category = db.Categories.FirstOrDefault(c => c.NameCategory.ToLower() == nameC);

		//		if (category == null)
		//		{
		//			Console.WriteLine("Категорію не знайдено.");
		//			return;
		//		}

		//		Console.WriteLine("Введіть текст питання для видалення:");
		//		string textQ = Console.ReadLine();

		//		var question = db.QuestionNews
		//			.FirstOrDefault(q => q.TextQ.ToLower() == textQ.ToLower() && q.CategoryId == category.Id);

		//		if (question == null)
		//		{
		//			Console.WriteLine("Питання не знайдено.");
		//			return;
		//		}

		//		try
		//		{
		//			// видаляємо відповіді для питання
		//			var answers = db.AnswerNews.Where(a => a.QuestionNewId == question.Id);
		//			db.AnswerNews.RemoveRange(answers);

		//			// видаляєио питання
		//			db.QuestionNews.Remove(question);
		//			db.SaveChanges();
		//			Console.WriteLine("Питання видалено.");
		//		}
		//		catch (Exception ex)
		//		{
		//			Console.WriteLine("Виникла помилка під час видалення питання: " + ex.Message);
		//		}
		//	}
		//}

		//public void DeleteAnswerNew()
		//{
		//	Console.WriteLine("Введіть назву категорії для видалення відповіді:");
		//	string nameC = Console.ReadLine().ToLower();

		//	using (QuizContext db = new QuizContext())
		//	{
		//		var category = db.Categories.FirstOrDefault(c => c.NameCategory.ToLower() == nameC);

		//		if (category == null)
		//		{
		//			Console.WriteLine("Категорію не знайдено.");
		//			return;
		//		}

		//		Console.WriteLine("Введіть текст питання, до якого належить відповідь:");
		//		string questionText = Console.ReadLine();

		//		var question = db.QuestionNews
		//			.FirstOrDefault(q => q.TextQ.ToLower() == questionText.ToLower() && q.CategoryId == category.Id);

		//		if (question == null)
		//		{
		//			Console.WriteLine("Питання не знайдено.");
		//			return;
		//		}

		//		Console.WriteLine("Введіть текст відповіді для видалення:");
		//		string textA = Console.ReadLine();

		//		var answer = db.AnswerNews
		//			.FirstOrDefault(a => a.Text.ToLower() == textA.ToLower() && a.QuestionNewId == question.Id);

		//		if (answer == null)
		//		{
		//			Console.WriteLine("Відповідь не знайдено.");
		//			return;
		//		}

		//		try
		//		{
		//			db.AnswerNews.Remove(answer);
		//			db.SaveChanges();
		//			Console.WriteLine("Відповідь видалено.");
		//		}
		//		catch (Exception ex)
		//		{
		//			Console.WriteLine("Виникла помилка під час видалення відповіді: " + ex.Message);
		//		}
		//	}
		//}


	}




}

