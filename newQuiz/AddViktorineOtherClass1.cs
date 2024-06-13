using newQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Helper
{
	internal class AddViktorineOtherClass1
	{
		public static void CreateCategory()
		{
			Console.WriteLine("Введіть Id нової вікторини:");
			int IdV = int.Parse(Console.ReadLine());

			using (QuizContext db = new QuizContext())
			{
				// перевіряємо чи вільний Id
				var existingCategory = db.Categories.FirstOrDefault(c => c.Id == IdV);
				if (existingCategory != null)
				{
					Console.WriteLine("Категорія з таким Id вже існує. Введіть інший Id.");
					return;
				}

				Console.WriteLine("Введіть назву категорії для нової вікторини: ");
				string nameViktorineNew = Console.ReadLine().ToUpper();

				var existingName = db.Categories.FirstOrDefault(c => c.NameCategory.ToUpper() == nameViktorineNew);
				if (existingName != null)
				{
					Console.WriteLine("Категорія з таким ім'ям вже існує. Введіть іншу назву.");
					return;
				}

				// створюємо і додаємо нову категорію
				Category category = new Category
				{
					Id = IdV,
					NameCategory = nameViktorineNew
				};
				db.Categories.Add(category);
				db.SaveChanges();
				Console.WriteLine("Категорію збережено.");
			}
		}

		public static void CreateQuestionForCategory()
		{
			Console.WriteLine("Введіть назву категорії куди треба додати питання");
			string nameNewViktorin = Console.ReadLine().ToUpper();

			using (QuizContext db = new QuizContext())
			{
				var categoryAddQuestion = db.Categories.FirstOrDefault(c => c.NameCategory.ToUpper() == nameNewViktorin);
				if (categoryAddQuestion == null)
				{
					Console.WriteLine("Категорію не знайдено.");
					return;
				}
				while (true)
				{
					Console.WriteLine("Введіть текст питання (або 'e' для виходу):");
					string questionText = Console.ReadLine();
					if (questionText.ToLower() == "e")
					{
						break;
					}

					QuestionNew question = new QuestionNew
					{
						TextQ = questionText,
						CategoryId = categoryAddQuestion.Id
					};

					db.QuestionNews.Add(question);
					db.SaveChanges();
					Console.WriteLine("Питання додано.");

					Console.WriteLine("Чи хочете додати ще одне питання? (y/n):");
					string addAnother = Console.ReadLine().ToLower();
					if (addAnother.ToLower() != "y")
					{
						break;
					}
				}
			}
		}

		public static void CreateAnswerForQuestion()
		{
			Console.WriteLine("Введіть питання для додавання відповіді:");
			string nameQuestion = Console.ReadLine().ToUpper();

			using (QuizContext db = new QuizContext())
			{
				var questionAddAnswer = db.QuestionNews.FirstOrDefault(c => c.TextQ.ToUpper() == nameQuestion);
				if (questionAddAnswer == null)
				{
					Console.WriteLine("Питання не знайдено.");
					return;
				}

				int correctAnswers = 0;
				int incorrectAnswers = 0;

				while (true)
				{
					if (correctAnswers == 1 && incorrectAnswers == 2)
					{
						Console.WriteLine("Додано достатню кількість відповідей для цього питання.");
						break;
					}

					Console.WriteLine("Додайте відповідь (або 'e' для виходу):");
					string answerText = Console.ReadLine();
					if (answerText.ToLower() == "e")
					{
						break;
					}

					Console.WriteLine("Чи це вірна відповідь? (t - так, f - ні):");
					string check = Console.ReadLine().ToLower();
					bool isCorrect;

					if (check == "t")
					{
						if (correctAnswers == 1)
						{
							Console.WriteLine("Вже додано одну вірну відповідь. Ви не можете додати більше.");
							continue;
						}
						isCorrect = true;
						correctAnswers++;
					}
					else if (check == "f")
					{
						if (incorrectAnswers == 2)
						{
							Console.WriteLine("Вже додано дві невірні відповіді. Ви не можете додати більше.");
							continue;
						}
						isCorrect = false;
						incorrectAnswers++;
					}
					else
					{
						Console.WriteLine("Некоректний вибір. Будь ласка, введіть 't' або 'f'.");
						continue;
					}

					AnswerNew answer = new AnswerNew
					{
						Text = answerText,
						IsCorrect = isCorrect,
						QuestionNewId = questionAddAnswer.Id
					};

					db.AnswerNews.Add(answer);
					db.SaveChanges();
					Console.WriteLine("Відповідь додано.");

					if (correctAnswers == 1 && incorrectAnswers == 2)
					{
						Console.WriteLine("Додано достатню кількість відповідей для цього питання.");
						break;
					}

					Console.WriteLine("Чи хочете додати ще одну відповідь? (y/n):");
					string addAnother = Console.ReadLine().ToLower();
					if (addAnother != "y")
					{
						break;
					}
				}
			}
		}

	}
}
