using newQuiz.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace newQuiz.Helper
{
	internal class StartQuizClass
	{
		public void StartQuiz(UserRegistrationClass loginUser, Category category)
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA");
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA");

			string userLogin = loginUser.Login;
			Console.WriteLine($"\nПочаток вікторини з {category.NameCategory}:\n");

			using (var context = new QuizContext())
			{
				List<string> questions = new List<string>();
				List<string> correctAnswers = new List<string>();

				switch (category.NameCategory)
				{
					case "Biology":
						questions = context.QuestionBiologys.Select(q => q.TextQ).ToList();
						correctAnswers = context.AnswerBiologys
						  .Where(a => a.IsCorrect)
						  .Select(a => a.Text)
						  .ToList();
						break;
					case "Astronomy":
						questions = context.QuestionAstronomys.Select(q => q.TextQ).ToList();
						correctAnswers = context.AnswerAstronomys
						  .Where(a => a.IsCorrect)
						  .Select(a => a.Text)
						  .ToList();
						break;
					case "Mixed":
						questions = context.QuestionMixes.Select(q => q.TextQ).ToList();
						correctAnswers = context.AnswerMixes
						  .Where(a => a.IsCorrect)
						  .Select(a => a.Text)
						  .ToList();
						break;
				}

				List<string> userAnswers = new List<string>();
				int correctAnswersCount = 0;

				for (int i = 0; i < questions.Count; i++)
				{
					Console.WriteLine($"{i + 1}. {questions[i]}");
					string userAnswer = Console.ReadLine().ToUpper(); // Зчитуємо відповідь користувача

					userAnswers.Add(userAnswer); // Додаємо відповідь до списку відповідей користувача

					// Порівнюємо відповіді користувача з правильними відповідями
					if (userAnswers[i].Equals(correctAnswers[i], StringComparison.OrdinalIgnoreCase))
					{
						correctAnswersCount++;
						Console.WriteLine("Правильно!");
					}
					else
					{
						Console.WriteLine("Неправильно!");
					}
				}

				Console.WriteLine($"Правильних відповідей: {correctAnswersCount} з {questions.Count}");

				SaveResults(userLogin, correctAnswersCount, questions.Count, category, context);

				//QuizrRsultsClass quizRes = new QuizrRsultsClass();
				if (category.NameCategory == "Biology")
                {
					PlaceInTheTableResultsPlayersBiology(loginUser, context);
				}
                if (category.NameCategory == "Astronomy")
                {
					PlaceInTheTableResultsPlayersAstronomy(loginUser, context);
				}
            }
		}
		public void SaveResults(string userLogin, int correctAnswersCount, int totalQuestions, Category category, QuizContext context)
		{
			var user = context.UserRegistrations.FirstOrDefault(u => u.LoginUser == userLogin);
			var categoryFromDb = context.Categories.FirstOrDefault(c => c.NameCategory == category.NameCategory);

			if (user == null || categoryFromDb == null)
			{
				Console.WriteLine("Помилка при збереженні результатів. Користувач або категорія не знайдені.");
				return;
			}

			var result = new QuizResult
			{
				UserRegistrationId = user.Id,
				UserRegistration = user,
				LoginUser = user.LoginUser,
				CategoryId = categoryFromDb.Id,
				Category = categoryFromDb,
				CorrectAnswers = correctAnswersCount,
				TotalQuestions = totalQuestions,
				DateTaken = DateTime.Now
			};

			context.QuizResults.Add(result);
			context.SaveChanges();
		}

		public static void PlaceInTheTableResultsPlayersBiology(UserRegistrationClass loginUser, QuizContext context)
		{
			var biologyResults = context.QuizResults
							.Where(r => r.Category.Id == 1)
							.OrderByDescending(r => r.CorrectAnswers)
							.ThenBy(r => r.DateTaken)
							.ToList();

			if (biologyResults.Count > 0)
			{
				int userRanking = 1;
				foreach (var result in biologyResults)
				{
					if (result.LoginUser == loginUser.Login)
					{
						Console.WriteLine($"\nКористувач: {result.LoginUser}," +
							$" Ваше місце: {userRanking}," +
							$" Правильні відповіді: {result.CorrectAnswers}/{result.TotalQuestions}");
						return;
					}
					userRanking++;
				}

				Console.WriteLine("Вашого результату немає в рейтингу.");
			}
			else
			{
				Console.WriteLine("Немає результатів для вікторини 'Біологія'.");
			}
		}

		public static void PlaceInTheTableResultsPlayersAstronomy(UserRegistrationClass loginUser, QuizContext context)
		{
			var astronomyResults = context.QuizResults
							.Where(r => r.Category.Id == 2)
							.OrderByDescending(r => r.CorrectAnswers)
							.ThenBy(r => r.DateTaken)
							.ToList();

			if (astronomyResults.Count > 0)
			{
				int userRanking = 1;
				foreach (var result in astronomyResults)
				{
					if (result.LoginUser == loginUser.Login)
					{
						Console.WriteLine($"\nКористувач: {result.LoginUser}," +
							$" Ваше місце: {userRanking}," +
							$" Правильні відповіді: {result.CorrectAnswers}/{result.TotalQuestions}");
						return;
					}
					userRanking++;
				}

				Console.WriteLine("Вашого результату немає в рейтингу.");
			}
			else
			{
				Console.WriteLine("Немає результатів для вікторини 'Астрономія'.");
			}
		}

	}



}


