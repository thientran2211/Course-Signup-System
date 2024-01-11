using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Data
{
    public class CourseSignupContext : DbContext
    {
        public CourseSignupContext(DbContextOptions<CourseSignupContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<LecturingSchedule> LecturingSchedules { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SubjectGroup> SubjectGroups { get; set; }
        public DbSet<SubjectGradeType> SubjectGradeTypes { get; set; }
        public DbSet<ScoreType> ScoreTypes { get; set; }
        public DbSet<TuitionFee> TuitionFees { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
    }
}
