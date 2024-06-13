using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Models
{
	internal class QuestionAstronomy
	{
		public int Id { get; set; }
		public string TextQ { get; set; }

		//список відповідей
		public virtual List<AnswerAstronomy> AnswerAstronomy { get; set; }
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
	}
}
