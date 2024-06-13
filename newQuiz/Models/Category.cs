using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Models
{
	internal class Category
	{
		public int Id { get; set; }
		public string NameCategory { get; set; }
		public virtual List<QuestionAstronomy> QuestionAstronomy { get; set; }
		public virtual List<QuestionBiology> QuestionBiology { get; set; }
		public virtual List<QuestionMixed> QuestionMixed { get; set; }
		public virtual List<QuestionNew> QuestionNew { get; set; }
	}
}
