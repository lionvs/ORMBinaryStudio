using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityBinaryStudio.DB;

namespace EntityBinaryStudio.DB
{
    sealed class Question
    {
        public int Id { get; set; }

        public Category QuestionCategory { get; set; }
        public string Text { get; set; }
        public List<Test> TestsInWhichExists { get; set; }

        public Question(Category questionCategory, string text)
        {
            QuestionCategory = questionCategory;
            Text = text;
            TestsInWhichExists = new List<Test>();
        }

        public Question()
        {
        }
    }
}
