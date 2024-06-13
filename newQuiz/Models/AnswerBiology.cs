using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Models
{
	internal class AnswerBiology
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public bool IsCorrect { get; set; }
		public int QuestionBiologyId { get; set; }
		public virtual QuestionBiology QuestionBiology { get; set; }
	}
}
