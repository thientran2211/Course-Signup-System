namespace Course_Signup_System.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Sex { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? ParentName { get; set; }
        public string? Image {  get; set; }

        public int CourseId { get; set; }
        public int ClassId { get; set; }
        public int RoleId { get; set; }

        public Role? Role { get; set; }
        public Class? Class { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public ICollection<TuitionFee>? TuitionFees { get; set; }
    }
}
