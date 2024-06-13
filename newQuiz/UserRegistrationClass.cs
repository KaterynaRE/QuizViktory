using newQuiz.Helper;
using newQuiz.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz
{
	internal class UserRegistrationClass
	{
		//зберігаємо посилання екзмл клас
		private readonly QuizContext _context;

		public string Password { get; set; }
		public string Login { get; set; }
		public DateTime DateBirthday { get; set; }
		public UserDifferenseClass UserDifference { get; set; }

		public UserRegistrationClass()
		{
			_context = new QuizContext();
			UserDifference = new UserDifferenseClass();
		}

		public UserRegistrationClass(string password, string login)
		{
			_context = new QuizContext();
			this.Password = password;
			this.Login = login;
			DateBirthday = new DateTime();
		}

		public void RegistrationLogIn()
		{
			Console.WriteLine("Введіть логін та пароль");
			while (true)
			{
				Console.WriteLine("Login: ");
				this.Login = Console.ReadLine();
				Console.WriteLine("Логін збережено");

				if (_context.UserRegistrations.Any(userP => userP.LoginUser == this.Login))
				{
					Console.WriteLine("Користувач з таким Логіном вже існує");
				}
				else
				{
					break;
				}
			}

			Console.WriteLine("Password: ");
			this.Password = Console.ReadLine();

			Console.WriteLine("Введіть дату народження у форматі (yyyy-MM-dd):");
			string inputDateBirthday = Console.ReadLine();
			DateTime dateBirth;
			if (DateTime.TryParse(inputDateBirthday, out dateBirth))
			{
				DateBirthday = dateBirth;
			}
			else
			{
				Console.WriteLine("Помилка вводу. Введіть дату народження у форматі (yyyy-MM-dd).");
				return;
			}

			var user = new UserRegistration
			{
				LoginUser = this.Login,
				PasswordUser = this.Password,
				DateBirthdayUser = this.DateBirthday
			};

			_context.UserRegistrations.Add(user);
			_context.SaveChanges();
			Console.WriteLine("Реєстрація успішна!");

			LogIn();
		}

		public string GetLogin()
		{
			return Login;
		}

		public string GetPassword()
		{
			return Password;
		}

		public void ChangePassword()
		{
			if (string.IsNullOrEmpty(this.Login))
			{
				Console.WriteLine("Логін користувача не встановлений.");
				return;
			}

			Console.WriteLine($"Логін поточного користувача: {this.Login}");

			Console.WriteLine("Введіть старий пароль: ");
			string oldPasw = Console.ReadLine();

			var user = _context.UserRegistrations.FirstOrDefault(u => u.LoginUser == this.Login);
			if (user != null && user.PasswordUser == oldPasw)
			{
				Console.WriteLine("Введіть новий пароль:");
				string paswNew = Console.ReadLine();
				Console.WriteLine("Повторіть новий пароль:");
				string paswNewNew = Console.ReadLine();
				if (paswNew == paswNewNew)
				{
					user.PasswordUser = paswNew;
					_context.SaveChanges();
					Console.WriteLine("Новий пароль збережено");
				}
				else
				{
					Console.WriteLine("Паролі не співпадають, спробуйте ще раз.");
				}
			}
			else
			{
				Console.WriteLine("Старий пароль введено неправильно або користувача не знайдено.");
			}
		}

		public void ChangeDateBirthday()
		{
			if (string.IsNullOrEmpty(this.Login))
			{
				Console.WriteLine("Логін користувача не встановлений.");
				return;
			}

			Console.WriteLine($"Логін поточного користувача: {this.Login}");
			var user = _context.UserRegistrations.FirstOrDefault(u => u.LoginUser == this.Login);
			Console.WriteLine("Введіть пароль: ");
			string pasw = Console.ReadLine();

			if (user != null && user.PasswordUser == pasw)
			{
				Console.WriteLine("Введіть нову дату народження у форматі (yyyy-MM-dd):");
				string inputDateBirthday = Console.ReadLine();
				DateTime newDateBirth;
				if (DateTime.TryParse(inputDateBirthday, out newDateBirth))
				{
					user.DateBirthdayUser = newDateBirth;
					_context.SaveChanges();
					Console.WriteLine("Нову дату народження збережено.");
				}
				else
				{
					Console.WriteLine("Помилка вводу. Введіть дату народження у форматі (yyyy-MM-dd).");
				}
			}
			else
			{
				Console.WriteLine("Пароль введено неправильно або користувача не знайдено.");
			}
		}

		public void LogIn()
		{
			Console.WriteLine("Введіть логін та пароль для входу");

			while (true)
			{
				Console.WriteLine("Login: ");
				this.Login = Console.ReadLine();
				Console.WriteLine("Password: ");
				string password = Console.ReadLine();

				var user = _context.UserRegistrations.FirstOrDefault(u => u.LoginUser == this.Login);
				if (user != null && user.PasswordUser == password)
				{
					this.Login = user.LoginUser;
					this.Password = user.PasswordUser;
					Console.WriteLine("Вхід успішний");
					break;
				}
				else
				{
					Console.WriteLine("Невірний логін або пароль, спробуйте ще раз.");
				}
			}
		}


	}
}


