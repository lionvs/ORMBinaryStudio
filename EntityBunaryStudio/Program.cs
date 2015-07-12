using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityBinaryStudio.DB;

namespace EntityBinaryStudio
{
    internal class Program
    {
        static MyNewDB db = new MyNewDB();

        private static void Main(string[] args)
        {
//           
            Console.WriteLine("Students who pass the test:\n");
            var pass = db.Works.Where(work => work.Result >= work.CurrTest.MarkNeeded).Select(work => work.TestUser);
            foreach (var user in pass)
            {
                Console.WriteLine(user.Id + " " + user.Name);

            }
            Console.WriteLine("Students who pass the test in enough time:\n");
            var passTime = db.Works.Where(work => work.Result >= work.CurrTest.MarkNeeded && work.TimeUsed <= work.CurrTest.MaxTime).Select(work => work.TestUser);
            foreach (var user in passTime)
            {
                Console.WriteLine(user.Id + " " + user.Name);

            }
            Console.WriteLine("Students who pass the test in not enough time:\n");

            var passNoTime = db.Works.Where(work => work.Result >= work.CurrTest.MarkNeeded && work.TimeUsed > work.CurrTest.MaxTime).Select(work => work.TestUser);
            foreach (var user in passNoTime)
            {
                Console.WriteLine(user.Id + " " + user.Name);

            }
            Console.WriteLine("Students sorted by city:\n");

            var groupbycity = db.Users.GroupBy(user => user.City).OrderBy(user => user.Key);
            foreach (var city in groupbycity)
            {
                Console.WriteLine("\n" + city.Key);
                foreach (var user in city)
                {
                    Console.WriteLine(user.Name);
                }
            }
            Console.WriteLine("successful Students sorted by city:\n");

            var groupbycitysuccess = db.Works.Where(work => work.Result >= work.CurrTest.MarkNeeded).Select(work => work.TestUser).GroupBy(user => user.City);
           // var suc = groupbycitysuccess.GroupBy(user => user.City).OrderBy(user => user.Key);
            foreach (var city in groupbycitysuccess)
            {
                Console.WriteLine("\n" + city.Key);
                foreach (var user in city)
                {
                    Console.WriteLine(user.Name);
                }
            } 
             Console.WriteLine("Questions rating:\n");

             var questRate = db.Questions.Select(test => new { count = test.TestsInWhichExists.Count, name = test.Text, id = test.Id }).OrderByDescending(test =>test.count);
             Console.WriteLine("QuestionText,  Id ,   Count in test");              

            foreach (var guest in questRate)
            {
                Console.WriteLine("{0}, {1} , {2}",guest.name , guest.id , guest.count);              
            }
            Console.WriteLine("Teacher rating:\n");

            var teachRate = db.Teachers.Select(teach => new { count = teach.Lectures.Count, name = teach.Name, id = teach.Id }).OrderByDescending(teach => teach.count);
            Console.WriteLine("TeacherName,  Id ,   Lectures Count");

            foreach (var teach in teachRate)
            {
                Console.WriteLine("{0}, {1} , {2}", teach.name, teach.id, teach.count);
            }
            //Средний бал тестов по категориям, отсортированый по убыванию.
            Console.WriteLine("Test Avarage rating:\n");

            var aver = db.Tests.GroupBy(test => test.TestCategory).Select(test => new { category = test.Key, avar = test.Average(test1 => test1.MarkNeeded) }).OrderByDescending(test => test.avar);
            Console.WriteLine("Test category,  Avarage");
            foreach (var test in aver)
            {

                Console.WriteLine("{0}, {1}", test.category, test.avar);              

            }
//            Рейтинг вопросов по набранным баллам
            //  Console.WriteLine("Question rating by mark:\n");

            //var rating = db.Tests.GroupBy(test => test.TestCategory).Select(test => new { category = test.Key, avar = test.Average(test1 => test1.MarkNeeded) }).OrderByDescending(test => test.avar);
            //Console.WriteLine("Test category,  Avarage");
            //foreach (var test in aver)
            //{

            //    Console.WriteLine("{0}, {1}", test.category, test.avar);
            //}
            Console.ReadLine();
        }
       

    }
}