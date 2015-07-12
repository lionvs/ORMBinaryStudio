using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityBinaryStudio.DB;

namespace EntityBinaryStudio.DB
{
    class Test
    {
        public int Id { get; set; }

        public string TestName { get; set; }
        public Category TestCategory { get; set; }
        public virtual List<Question> Questions { get; set; }
        public TimeSpan MaxTime { get; set; }
        public int MarkNeeded { get; set; }

        public Test(string testName, Category testCategory, List<Question> questions, TimeSpan maxTime, int markNeeded)
        {
            TestName = testName;
            TestCategory = testCategory;
            Questions = questions;
            MaxTime = maxTime;
            MarkNeeded = markNeeded;
           // Questions = new List<Question>();

        }

        public Test()
        {
        }
    }
}
