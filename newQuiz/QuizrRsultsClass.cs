using newQuiz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Helper
{
	internal class QuizrRsultsClass
	{
		//public void PlaceInTheTableResultsPlayersBiology(UserRegistrationClass loginUser, QuizContext context)
		//{
		//	var biologyResults = context.QuizResults
		//					.Where(r => r.Category.Id == 1)
		//					.OrderByDescending(r => r.CorrectAnswers)
		//					.ThenBy(r => r.DateTaken)
		//					.ToList();

		//	if (biologyResults.Count > 0)
		//	{
		//		int userRanking = 1;
		//		foreach (var result in biologyResults)
		//		{
		//			if (result.LoginUser == loginUser.Login)
		//			{
		//				Console.WriteLine($"\nКористувач: {result.LoginUser}," +
		//					$" Ваше місце: {userRanking}," +
		//					$" Правильні відповіді: {result.CorrectAnswers}/{result.TotalQuestions}");
		//				return;
		//			}
		//			userRanking++;
		//		}

		//		Console.WriteLine("Вашого результату немає в рейтингу.");
		//	}
		//	else
		//	{
		//		Console.WriteLine("Немає результатів для вікторини 'Біологія'.");
		//	}
		//}

		//public void PlaceInTheTableResultsPlayersAstronomy(UserRegistrationClass loginUser, QuizContext context)
		//{
		//	var astronomyResults = context.QuizResults
		//					.Where(r => r.Category.Id == 2)
		//					.OrderByDescending(r => r.CorrectAnswers)
		//					.ThenBy(r => r.DateTaken)
		//					.ToList();

		//	if (astronomyResults.Count > 0)
		//	{
		//		int userRanking = 1;
		//		foreach (var result in astronomyResults)
		//		{
		//			if (result.LoginUser == loginUser.Login)
		//			{
		//				Console.WriteLine($"\nКористувач: {result.LoginUser}," +
		//					$" Ваше місце: {userRanking}," +
		//					$" Правильні відповіді: {result.CorrectAnswers}/{result.TotalQuestions}");
		//				return;
		//			}
		//			userRanking++;
		//		}

		//		Console.WriteLine("Вашого результату немає в рейтингу.");
		//	}
		//	else
		//	{
		//		Console.WriteLine("Немає результатів для вікторини 'Астрономія'.");
		//	}
		//}
		public void LoadResultsBiology(UserRegistrationClass loginUser, QuizContext context)
		{
			// Завантажити результати вікторин, відфільтровані за категорією (Біологія) і логіном користувача з завантаженням Category
			var results = context.QuizResults
				.Include(r => r.Category)
								.Where(r => r.Category.NameCategory == "Biology" && r.LoginUser == loginUser.Login)
								.OrderByDescending(r => r.CorrectAnswers)
								.ThenBy(r => r.DateTaken)
								.ToList();

			// Вивести загальну кількість результатів
			Console.WriteLine($"Загальна кількість результатів: {results.Count}");
			// Вивести логін користувача для фільтрації
			Console.WriteLine($"Логін користувача для фільтрації: {loginUser.Login}");

			// Перевірити, чи є результати
			if (results.Count > 0)
			{
				Console.WriteLine("Усі результати для користувача:");
				// Вивести деталі для кожного результату
				foreach (var result in results)
				{
					Console.WriteLine($"\nКористувач: {result.LoginUser}," +
						$"\nДата: {result.DateTaken}, " +
						$"\nНомер категорії: {result.CategoryId}," +
						$"\nНазва категорії: {result.Category.NameCategory}," + // доступ до назви категорії
						$"\nПравильні відповіді: {result.CorrectAnswers}/{result.TotalQuestions}");
				}
			}
			else
			{
				// Якщо результатів немає, вивести повідомлення
				Console.WriteLine("Результатів немає.");
			}
		}

		public void LoadResultsAstronomy(UserRegistrationClass loginUser, QuizContext context)
		{
			// результати, відфільтровані за категорією (Астрономія) і логіном користувача з завантаженням Category
			var results = context.QuizResults
				.Include(r => r.Category)
								.Where(r => r.Category.NameCategory == "Astronomy" && r.LoginUser == loginUser.Login)
								.OrderByDescending(r => r.CorrectAnswers)
								.ThenBy(r => r.DateTaken)
								.ToList();

			//// Вивести загальну кількість результатів
			Console.WriteLine($"Загальна кількість результатів: {results.Count}");
			//// Вивести логін користувача для фільтрації
			Console.WriteLine($"Логін користувача для фільтрації: {loginUser.Login}");

			// Перевірити, чи є результати
			if (results.Count > 0)
			{
				Console.WriteLine("Усі результати для користувача:");
				// Вивести деталі для кожного результату
				foreach (var result in results)
				{
					Console.WriteLine($"\nКористувач: {result.LoginUser}," +
						$"\nДата: {result.DateTaken}, " +
						$"\nНомер категорії: {result.CategoryId}," +
						$"\nНазва категорії: {result.Category.NameCategory}," +
						$"\nПравильні відповіді: {result.CorrectAnswers}/{result.TotalQuestions}");
				}
			}
			else
			{
				Console.WriteLine("Результатів немає.");
			}
		}

		public void Top20Biology(QuizContext context)
		{
			// результати, відфільтровані за категорією (Biology)
			var biologyResults = context.QuizResults
				.Include(r => r.Category)
								.Where(r => r.Category.NameCategory == "Biology")
								.OrderByDescending(r => r.CorrectAnswers)
								.ThenBy(r => r.DateTaken)
								.Take(20)
								.ToList();
			
			if (biologyResults.Count > 0)
			{
				int userRanking = 1;
				Console.WriteLine("\nТоп 20 результатів вікторини 'Біологія':");
				foreach (var result in biologyResults)
				{
					Console.WriteLine($"\nКористувач: {result.LoginUser}," +
									  $"\nМісце: {userRanking}," +
									  $"\nДата: {result.DateTaken}, " +
									  $"\nНазва вікторини: {result.Category.NameCategory}" +
									  $"\nПравильні відповіді: {result.CorrectAnswers}/{result.TotalQuestions}");
					userRanking++;
				}
			}
			else
			{
				Console.WriteLine("Немає результатів для вікторини 'Біологія'.");
			}
		}
		public void Top20Astronomy(QuizContext context)
		{
			// результати, відфільтровані за категорією (Biology)
			var astronomyResults = context.QuizResults
				.Include(r => r.Category)
								.Where(r => r.Category.NameCategory == "Astronomy")
								.OrderByDescending(r => r.CorrectAnswers)
								.ThenBy(r => r.DateTaken)
								.Take(20)
								.ToList();

			if (astronomyResults.Count > 0)
			{
				int userRanking = 1;
				Console.WriteLine("\nТоп 20 результатів вікторини 'Астрономія':");
				foreach (var result in astronomyResults)
				{
					Console.WriteLine($"\nКористувач: {result.LoginUser}," +
									  $"\nМісце: {userRanking}," +
									  $"\nДата: {result.DateTaken}, " +
									  $"\nНазва вікторини: {result.Category.NameCategory}" +
									  $"\nПравильні відповіді: {result.CorrectAnswers}/{result.TotalQuestions}");
					userRanking++;
				}
			}
			else
			{
				Console.WriteLine("Немає результатів для вікторини 'Астрономія'.");
			}
		}



	}
}
