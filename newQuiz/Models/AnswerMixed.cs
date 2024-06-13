﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newQuiz.Models
{
	internal class AnswerMixed
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public bool IsCorrect { get; set; }
		public int QuestionMixedId { get; set; }
		public virtual QuestionMixed QuestionMixed { get; set; }
	}
}
