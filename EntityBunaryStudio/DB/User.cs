using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityBinaryStudio.DB;

namespace EntityBinaryStudio.DB
{
    class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string University { get; set; }
        public  Category UserCategory { get; set; }
        public virtual List<TestWork> Works { get; set; }

        public User(string name, string email, int age, string university, string city, Category userCategory)
        {
            Name = name;
            Email = email;
            Age = age;
            University = university;
            City = city;
            UserCategory = userCategory;
            Works = new List<TestWork>();
        }

        public User()
        {
        }
    }
}
