using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBinaryStudio.DB
{
    class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Lecture> Lectures { get; set; }

        public Teacher(string name)
        {
            Name = name;
            Lectures = new List<Lecture>();
        }

        public Teacher()
        {
        }
    }
}
