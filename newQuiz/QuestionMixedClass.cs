using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz
{
	internal class QuestionMixedClass
	{
		public List<string> QuestionMix(List<string> biologyQuestions, List<string> astronomyQuestions, int count)
		{
			var mixedQuestions = new List<string>();
			mixedQuestions.AddRange(biologyQuestions.Take(count));
			mixedQuestions.AddRange(astronomyQuestions.Take(count));
			return mixedQuestions;
		}
	}
}
