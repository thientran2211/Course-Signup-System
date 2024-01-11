namespace Course_Signup_System.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }

        public int SubjectGroupId { get; set; }
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
        public SubjectGroup? SubjectGroup { get; set; }

        public ICollection<SubjectGradeType>? Grades { get; set; }
    }
}
