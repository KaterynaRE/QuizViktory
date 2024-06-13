using newQuiz.Helper;
using newQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz
{
	internal class AdminRegistrationClass
	{
		private readonly QuizContext _context;

		public string Password { get; set; }
		public string Login { get; set; }

		public AdminDiferenseCass AdminDifference { get; set; }

		public AdminRegistrationClass()
		{
			_context = new QuizContext();
			AdminDifference = new AdminDiferenseCass();
		}
		public AdminRegistrationClass(string password, string login)
		{
			_context = new QuizContext();
			this.Password = password;
			this.Login = login;
		}

		public void RegistrationLogInAdmin()
		{
			Console.WriteLine("Введіть логін та пароль");
			while (true)
			{
				Console.WriteLine("Login: ");
				this.Login = Console.ReadLine();
				Console.WriteLine("Логін збережено");

				if (_context.AdminRegistrations.Any(adminP => adminP.LoginAdmin == this.Login))
				{
					Console.WriteLine("Адміністратор з таким Логіном вже існує");
				}
				else
				{
					break;
				}
			}

			Console.WriteLine("Password: ");
			this.Password = Console.ReadLine();

			var admin = new AdminRegistration
			{
				LoginAdmin = this.Login,
				PasswordAdmin = this.Password,
			};

			_context.AdminRegistrations.Add(admin);
			_context.SaveChanges();
			Console.WriteLine("Реєстрація успішна!");

			LogInAdmin();
		}

		public string GetLoginAdmin()
		{
			return Login;
		}

		public string GetPasswordAdmin()
		{
			return Password;
		}

		public void LogInAdmin()
		{
			Console.WriteLine("Введіть логін та пароль для входу або настиніть: Е - Вихід");

			while (true)
			{
				Console.WriteLine("Login: ");
				this.Login = Console.ReadLine();

				if (this.Login.Equals("E", StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("Вихід");
					break;
				}

				Console.WriteLine("Password: ");
				string password = Console.ReadLine();

				var admin = _context.AdminRegistrations.FirstOrDefault(a => a.LoginAdmin == this.Login);
				if (admin != null && admin.PasswordAdmin == password)
				{
					this.Login = admin.LoginAdmin;
					this.Password = admin.PasswordAdmin;
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
