using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBinaryStudio.DB
{
    class Lecture
    {
        public int Id { get; set; }
        public virtual List<Teacher> LectureTeachers { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }

        public Lecture(Category category, string description)
        {
            Category = category;
            Description = description;
            LectureTeachers = new List<Teacher>();
        }

        public Lecture()
        {
        }
    }
}
