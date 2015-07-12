using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBinaryStudio.DB
{
    class TestWork
    {
        public int Id { get; set; }
        public virtual Test CurrTest { get; set; }
        public virtual User TestUser { get; set; }
        public int Result { get; set; }
        public TimeSpan TimeUsed { get; set; }

        public TestWork(Test currTest, TimeSpan timeUsed, int result)
        {
            CurrTest = currTest;
            TimeUsed = timeUsed;
            Result = result;
        }

        public TestWork()
        {
        }
    }
}
