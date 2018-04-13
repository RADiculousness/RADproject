using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentServer.Models.StudentModel
{
    public class StudentDBContext :DbContext
    {
        public StudentDBContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lecture> Deliveries { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<StudentAttendance> AttendanceList { get; set; }
        public DbSet<Login> UserLogin { get; set; }
        //

        public System.Data.Entity.DbSet<StudentServer.Models.StudentModel.StudentGrade> StudentGrades { get; set; }
    }
}