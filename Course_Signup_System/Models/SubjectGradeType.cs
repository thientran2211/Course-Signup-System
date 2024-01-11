namespace Course_Signup_System.Models
{
    public class SubjectGradeType
    {
        public int Id { get; set; }
        public int ScoreColumn { get; set; }
        public int RequiredScoreColumn { get; set;}

        public int CourseId {  get; set; }
        public int SubjectId { get; set; }
        public int ScoreTypeId { get; set; }

        public Course? Course { get; set; }
        public Subject? Subject { get; set; }
        public ScoreType? ScoreType {  get; set; } 
    }
}
