using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Models
{
	internal class UserRegistration
	{
		public int Id { get; set; }
		public string PasswordUser { get; set; }
		public string LoginUser { get; set; }
		public DateTime DateBirthdayUser { get; set; }
	}
}
