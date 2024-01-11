namespace Course_Signup_System.Models
{
    public class ScoreType
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<SubjectGradeType>? SubjectGrades { get; set;}
    }
}
