using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Models
{
	internal class QuizResult
	{
		public int Id { get; set; }
		public int UserRegistrationId { get; set; }
		public virtual UserRegistration UserRegistration { get; set; }
		public string LoginUser { get; set; }
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
		public DateTime DateTaken { get; set; }
		public int CorrectAnswers { get; set; }
		public int TotalQuestions { get; set; }
	}
}
