namespace StudentServer.Migrations.StudentMigrations
{
    using CsvHelper;
    using Microsoft.AspNet.Identity;
    using Models.DTO;
    using Models.StudentModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentServer.Models.StudentModel.StudentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\StudentMigrations";
        }

        protected override void Seed(StudentServer.Models.StudentModel.StudentDBContext context)
        {
            {
                SeedStudents(context);
                SeedModules(context);
                SeedLecturers(context);
                SeedEnrollments(context);
                SeedDelivery(context,
                                context.Modules.First(m => m.ModuleName.Equals("AI")),
                                context.Lecturers.First(l => l.FirstName.Equals("Paul")
                                                        && l.SecondName.Equals("Powell")));
                context.SaveChanges();
                SeedUser(context);
                base.Seed(context);
            }
        }
        private void SeedDelivery(StudentDBContext context, Models.StudentModel.Module module, Lecturer lecturer)
        {

            int[] slots = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            string[] days = new string[] { "Mon", "Tues", "Wed", "Thurs", "Fri" };
            int slot = new Random().Next(slots.Count());
            string day = days[new Random().Next(days.Count())];
            context.Deliveries.AddOrUpdate(d => new { d.LecturerId, d.ModuleId, d.Day, d.TimeSlot },
              new Lecture[] {
                    new Lecture {
                        LecturedBy = lecturer,
                        LecturedModule = module,
                        Day = day,
                        TimeSlot =new TimeSpan(slot,0,0)
                  } });

            context.SaveChanges();
        }

        private void SeedEnrollments(StudentDBContext context)
        {
            // get the first module
            var module = context.Modules.First();
            // get a random selection of students
            foreach (var student in GetRandomStudent(context, 10))
            {
                // enroll the students on the module
                context.Enrollments.AddOrUpdate(e => new { e.StudentId, e.ModuleId },
                    new Enrollment[] {
                        new Enrollment { StudentEnrolled = student,
                                         EnrolledIn = module,
                                        EnrollmentDate = DateTime.Now
                        }
                    });
            }
            context.SaveChanges();
        }

        // Get a ratom count of students 
        private Student[] GetRandomStudent(StudentDBContext Context, int count)
        {
            var randomids = Context.Students.Select(s => new { s.id, order = Guid.NewGuid() })
                                    .OrderBy(o => o.order)
                                    .Select(s => s.id);
            // take count where student record contains selected random ids
            return Context.Students.Where(s => randomids.Contains(s.id))
                                   .Take(count).ToArray();

        }


        private void SeedLecturers(StudentDBContext context)
        {
            context.Lecturers.AddOrUpdate(p => new { p.FirstName, p.SecondName },
                new Lecturer[]
                {
                    new Lecturer { FirstName="Paul", SecondName="Powell" },
                    new Lecturer { FirstName="Vivion", SecondName="Kinsella" },
                });
            context.SaveChanges();
        }

        private void SeedModules(StudentDBContext context)
        {
            context.Modules.AddOrUpdate(p => p.ModuleName,
                new Models.StudentModel.Module[] {
                    new Models.StudentModel.Module { ModuleName = "AI", Description = "Artificial Intelligence" },
                    new Models.StudentModel.Module { ModuleName = "RAD301", Description = "Rich Application Development 1" },
                    new Models.StudentModel.Module { ModuleName = "RAD302", Description = "Rich Application Development 2" }
                });
            context.SaveChanges();
        }

        public void SeedStudents(StudentDBContext context)
        {
            #region Student
            context.Students.AddOrUpdate(p => p.Email,
                                 new Student
                                 {
                                     RegistrationID = "S00000001",
                                     FirstName = "James",
                                     LastName = "Bryan",
                                     Email = "S00000001" + "@mail.itsligo.ie"
                                 }, new Student
                                 {
                                     RegistrationID = "S00000002",
                                     FirstName = "Bryan",
                                     LastName = "Foley",
                                     Email = "S00000002" + "@mail.itsligo.ie"
                                 },
                                  new Student
                                  {
                                      RegistrationID = "S00000003",
                                      FirstName = "Trevor",
                                      LastName = "Gilmartin",
                                      Email = "S00000003" + "@mail.itsligo.ie"
                                  }, new Student
                                  {
                                      RegistrationID = "S00000004",
                                      FirstName = "Bronagh",
                                      LastName = "Gray",
                                      Email = "S00000004" + "@mail.itsligo.ie"
                                  }, new Student
                                  {
                                      RegistrationID = "S00000005",
                                      FirstName = "Joanne",
                                      LastName = "Heraghty",
                                      Email = "S00000005" + "@mail.itsligo.ie"
                                  },
                                   new Student
                                   {
                                       RegistrationID = "S00000006",
                                       FirstName = "Lukasz",
                                       LastName = "Kuron",
                                       Email = "S00000006" + "@mail.itsligo.ie"
                                   }, new Student
                                   {
                                       RegistrationID = "S00000007",
                                       FirstName = "Adam",
                                       LastName = "Lee",
                                       Email = "S00000007" + "@mail.itsligo.ie"
                                   }
                                 );
            #endregion

            context.SaveChanges();
        }
        private void SeedUser(StudentDBContext context)
        {
            PasswordHasher ps = new PasswordHasher();

            context.UserLogin.AddOrUpdate(u => u.Username,
                new  Models.StudentModel.Login
                {
                    Username = "S0000001",
                    Password = ps.HashPassword("Test$123")
                });
        }
    }
}
