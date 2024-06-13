using newQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Helper
{
	internal class DeletingViktoryneOtherClass1
	{
		public static void DeleteViktorineAstronomy()
		{
			using (QuizContext db = new QuizContext())
			{
				var delCat = db.Categories.FirstOrDefault(c => c.NameCategory == "Astronomy");

				if (delCat == null)
				{
					Console.WriteLine("Категорію не знайдено.");
					return;
				}

				try
				{
					// Знаходимо всі питання, пов'язані з категорією
					var questions = db.QuestionAstronomys.Where(q => q.CategoryId == delCat.Id).ToList();

					// Для кожного питання знаходимо і видаляємо пов'язані відповіді
					foreach (var question in questions)
					{
						var answers = db.AnswerAstronomys.Where(a => a.QuestionAstronomyId == question.Id).ToList();
						db.AnswerAstronomys.RemoveRange(answers);
					}

					// Видаляємо всі питання, пов'язані з категорією
					db.QuestionAstronomys.RemoveRange(questions);

					// Видаляємо категорію
					db.Categories.Remove(delCat);
					db.SaveChanges();
					Console.WriteLine("Категорію та всі пов'язані питання і відповіді видалено.");
				}
				catch (Exception ex)
				{
					Console.WriteLine("Виникла помилка під час видалення категорії: " + ex.Message);
				}
			}
		}

		public static void DeleteViktorineBiology()
		{
			using (QuizContext db = new QuizContext())
			{
				var delCat = db.Categories.FirstOrDefault(c => c.NameCategory == "Biology");

				if (delCat == null)
				{
					Console.WriteLine("Категорію не знайдено.");
					return;
				}

				try
				{
					// Знаходимо всі питання, пов'язані з категорією
					var questions = db.QuestionBiologys.Where(q => q.CategoryId == delCat.Id).ToList();

					// Для кожного питання знаходимо і видаляємо пов'язані відповіді
					foreach (var question in questions)
					{
						var answers = db.AnswerBiologys.Where(a => a.QuestionBiologyId == question.Id).ToList();
						db.AnswerBiologys.RemoveRange(answers);
					}

					// Видаляємо всі питання, пов'язані з категорією
					db.QuestionBiologys.RemoveRange(questions);

					// Видаляємо категорію
					db.Categories.Remove(delCat);
					db.SaveChanges();
					Console.WriteLine("Категорію та всі пов'язані питання і відповіді видалено.");
				}
				catch (Exception ex)
				{
					Console.WriteLine("Виникла помилка під час видалення категорії: " + ex.Message);
				}
			}
		}

		public static void DeleteViktorineC()
		{
			Console.WriteLine("Введіть назву вікторини для видалення:");
			string nameC = Console.ReadLine().ToLower();

			using (QuizContext db = new QuizContext())
			{
				var delCat = db.Categories.FirstOrDefault(c => c.NameCategory.ToLower() == nameC);

				if (delCat == null)
				{
					Console.WriteLine("Категорію не знайдено.");
					return;
				}

				try
				{
					// Знаходимо всі питання, пов'язані з категорією
					var questions = db.QuestionNews.Where(q => q.CategoryId == delCat.Id).ToList();

					// Для кожного питання знаходимо і видаляємо пов'язані відповіді
					foreach (var question in questions)
					{
						var answers = db.AnswerNews.Where(a => a.QuestionNewId == question.Id).ToList();
						db.AnswerNews.RemoveRange(answers);
					}

					// Видаляємо всі питання, пов'язані з категорією
					db.QuestionNews.RemoveRange(questions);

					// Видаляємо категорію
					db.Categories.Remove(delCat);
					db.SaveChanges();
					Console.WriteLine("Категорію та всі пов'язані питання і відповіді видалено.");
				}
				catch (Exception ex)
				{
					Console.WriteLine("Виникла помилка під час видалення категорії: " + ex.Message);
				}
			}
		}

		public static void DeleteQuestionNew()
		{
			Console.WriteLine("Введіть назву категорії для видалення питання:");
			string nameC = Console.ReadLine().ToLower();

			using (QuizContext db = new QuizContext())
			{
				var category = db.Categories.FirstOrDefault(c => c.NameCategory.ToLower() == nameC);

				if (category == null)
				{
					Console.WriteLine("Категорію не знайдено.");
					return;
				}

				Console.WriteLine("Введіть текст питання для видалення:");
				string textQ = Console.ReadLine();

				var question = db.QuestionNews
					.FirstOrDefault(q => q.TextQ.ToLower() == textQ.ToLower() && q.CategoryId == category.Id);

				if (question == null)
				{
					Console.WriteLine("Питання не знайдено.");
					return;
				}

				try
				{
					// видаляємо відповіді для питання
					var answers = db.AnswerNews.Where(a => a.QuestionNewId == question.Id);
					db.AnswerNews.RemoveRange(answers);

					// видаляєио питання
					db.QuestionNews.Remove(question);
					db.SaveChanges();
					Console.WriteLine("Питання видалено.");
				}
				catch (Exception ex)
				{
					Console.WriteLine("Виникла помилка під час видалення питання: " + ex.Message);
				}
			}
		}

		public static void DeleteAnswerNew()
		{
			Console.WriteLine("Введіть назву категорії для видалення відповіді:");
			string nameC = Console.ReadLine().ToLower();

			using (QuizContext db = new QuizContext())
			{
				var category = db.Categories.FirstOrDefault(c => c.NameCategory.ToLower() == nameC);

				if (category == null)
				{
					Console.WriteLine("Категорію не знайдено.");
					return;
				}

				Console.WriteLine("Введіть текст питання, до якого належить відповідь:");
				string questionText = Console.ReadLine();

				var question = db.QuestionNews
					.FirstOrDefault(q => q.TextQ.ToLower() == questionText.ToLower() && q.CategoryId == category.Id);

				if (question == null)
				{
					Console.WriteLine("Питання не знайдено.");
					return;
				}

				Console.WriteLine("Введіть текст відповіді для видалення:");
				string textA = Console.ReadLine();

				var answer = db.AnswerNews
					.FirstOrDefault(a => a.Text.ToLower() == textA.ToLower() && a.QuestionNewId == question.Id);

				if (answer == null)
				{
					Console.WriteLine("Відповідь не знайдено.");
					return;
				}

				try
				{
					db.AnswerNews.Remove(answer);
					db.SaveChanges();
					Console.WriteLine("Відповідь видалено.");
				}
				catch (Exception ex)
				{
					Console.WriteLine("Виникла помилка під час видалення відповіді: " + ex.Message);
				}
			}
		}


	}
}
