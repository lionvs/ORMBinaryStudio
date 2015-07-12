using EntityBinaryStudio.DB;

namespace EntityBinaryStudio.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyNewDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyNewDB context)
        {
            for (int i = 0; i < 50; i++)
            {
                Question question = new Question((Category)(i % 6), "What is it" + i + "?");
                context.Questions.Add(question);
                }
            context.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                Test test = new Test("NewTest" + i, (Category)(i % 6), context.Questions.OrderBy(question => question.Text).Skip(i * 5).Take(5).ToList(), new TimeSpan(1, 0, 0), 75);
                test.Questions = context.Questions.OrderBy(question => question.Text).Skip((i * 5) % 10).Take(5).ToList();
                context.Tests.Add(test);
            }
            context.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
               // context.Users.Add(new User("Ya" + i, "some" + i + "@gmail.com", 21 + i, "LNU", "Lviv", (Category)(i % 6)));
                TestWork work = new TestWork(context.Tests.ToArray()[i], new TimeSpan(0, 52 + i, 0), 70 + i);
                User usr = new User("Ya" + i, "some" + i + "@gmail.com", 21 + i, "LNU", "Lviv", (Category) (i%6));
                usr.Works.Add(work);
                context.Users.Add(usr);
            }
            for (int i = 0; i < 7; i++)
            {
                TestWork work = new TestWork(context.Tests.ToArray()[i], new TimeSpan(0, 50 + i, 0), 72 + i);
                User usr = new User("StudentNew" + i, "kiyevStudent" + i + "@gmail.com", 20 + i, "KNU", "Kiyev",
                    (Category) (i%6));
                usr.Works.Add(work);
                context.Users.Add(usr);
            }
            for (int i = 0; i < 5; i++)
            {
               // context.Users.Add(new User("User" + i, "user" + i + "@mail.ru", 20 + i, "Mogilanka", "Kyev", (Category)(i % 6)));
                TestWork work = new TestWork(context.Tests.ToArray()[i], new TimeSpan(0, 59 + i, 0), 73 + i);
                User usr = new User("User" + i, "user" + i + "@mail.ru", 20 + i, "Mogilanka", "Kyev", (Category) (i%6));
                usr.Works.Add(work);
                work.TestUser = usr;
                context.Works.Add(work);
                context.Users.Add(usr);
            }
          
            
          
            for (int i = 0; i < 20; i++)
            {
                Lecture lecture = new Lecture((Category)(i % 6),"Some boring lecture #" + i);

                context.Lectures.Add(lecture);
                context.SaveChanges();
            }
            for (int i = 0; i < 10; i++)
            {
                Teacher teacher = new Teacher("SomeTeacher" + i);
                teacher.Lectures = context.Lectures.OrderBy(lectures => lectures.Description).Skip((i * 5) % 20).Take(5).ToList();
                context.Teachers.Add(teacher);

            }

        }
    }
}
