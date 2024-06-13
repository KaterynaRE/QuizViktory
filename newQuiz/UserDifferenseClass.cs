using newQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Helper
{
	internal class UserDifferenseClass
	{
		public void MenuUser(UserRegistrationClass loginUser)
		{
			while (true)
			{
				Console.WriteLine("\nОберіть розділ:");
				Console.WriteLine("1 Стартувати нову вікторину");
				Console.WriteLine("2 Переглянути результати своїх минулих вікторин");
				Console.WriteLine("3 Переглянути Топ-20 з конкретної вікторини");
				Console.WriteLine("4 Змінити налаштування");
				Console.WriteLine("5 Вихід");

				string choiceRozdil = Console.ReadLine();

				switch (choiceRozdil)
				{
					case "1":
						StartNewVitorin(loginUser);
						break;
					case "2":
						TheResultsOfYourPastQuizzes(loginUser);
						break;
					case "3":
						Top20FromSpecificQuiz();
						break;
					case "4":
						ChangeSettingsUser(loginUser);
						break;
					case "5":
						return; // Exit the method

					default:
						Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
						break;
				}
			}
		}

		public void StartNewVitorin(UserRegistrationClass loginUser)
		{
			while (true)
			{
				Console.WriteLine("\nОберіть розділ вікторини:\nB - Біологія  A - Астрономія  M - Змішана вікторина");
				Console.WriteLine("E - назад     5 - вихід");
				string choiceViktoryn = Console.ReadLine().ToUpper();
				switch (choiceViktoryn)
				{
					case "B":
						StartQuizClass biologyQuiz = new StartQuizClass();
						biologyQuiz.StartQuiz(loginUser, new Category { NameCategory = "Biology" });
						break;
					case "A":
						StartQuizClass astronomyQuiz = new StartQuizClass();
						astronomyQuiz.StartQuiz(loginUser, new Category { NameCategory = "Astronomy" });
						break;
					case "M":
						//Astronomy astronomy1 = new Astronomy();
						//Biology biology1 = new Biology();
						//MixedViktoryn viktoryn = new MixedViktoryn();

						//viktoryn.AddQuestionsFromAstronomy(astronomy1, 5);
						//viktoryn.AddQuestionsFromBiology(biology1, 5);

						//viktoryn.StartQuiz(loginUser);
						break;
					case "E":
						return;
					case "5":
						return;
					default:
						Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
						break;
				}
			}

		}

		//результати своїх минулих вікторин
		public void TheResultsOfYourPastQuizzes(UserRegistrationClass loginUser)
		{
			QuizContext context = new QuizContext();
			QuizrRsultsClass quizr = new QuizrRsultsClass();
			while (true)
			{
				Console.WriteLine("\nОберіть вікторину щоб побачити результати: B - Біологія, A - Астрономія, M - Змішана вікторина");
				Console.WriteLine("E - назад");
				string choiceViktoryn = Console.ReadLine().ToUpper();
				switch (choiceViktoryn)
				{
					case "B":
						quizr.LoadResultsBiology(loginUser, context);
						break;
					case "A":
						quizr.LoadResultsAstronomy(loginUser, context);
						break;
					case "M":
						//MixedViktoryn.LoadResultsMixed(loginUser);
						break;
					case "E":
						return;
					default:
						Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
						break;
				}
			}
		}

		//Топ-20 з конкретної вікторини
		public void Top20FromSpecificQuiz()
		{
			QuizContext context = new QuizContext();
			QuizrRsultsClass quizr = new QuizrRsultsClass();
			while (true)
			{
				Console.WriteLine("\nОберіть вікторину щоб побачити Top-20: B - Біологія, A - Астрономія, M - Змішана вікторина");
				Console.WriteLine("E - назад");
				string choiceViktoryn = Console.ReadLine().ToUpper();
				switch (choiceViktoryn)
				{
					case "B":
						quizr.Top20Biology(context);
						break;
					case "A":
						quizr.Top20Astronomy(context);
						break;
					case "M":
						//quizr.Top20Mixed();
						break;
					case "E":
						return;
					default:
						Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
						break;
				}
			}
		}

		public void ChangeSettingsUser(UserRegistrationClass loginUser)
		{
			while (true)
			{
				Console.WriteLine("\nОберіть що бажаєте змінити: P - пароль, D - дата народження");
				Console.WriteLine("E - назад");
				string choiceViktoryn = Console.ReadLine().ToUpper();
				switch (choiceViktoryn)
				{
					case "P":
						loginUser.ChangePassword();
						break;
					case "D":
						loginUser.ChangeDateBirthday();
						break;
					case "E":
						return;
					default:
						Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
						break;
				}
			}
		}
	}
}
