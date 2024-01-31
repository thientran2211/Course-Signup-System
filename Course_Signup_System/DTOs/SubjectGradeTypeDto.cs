using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.DTOs
{
    public class SubjectGradeTypeDto
    {
        public int ScoreColumn { get; set; }
        public int RequiredScoreColumn { get; set; }

        [Required]
        public int CourseId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int ScoreTypeId { get; set; }
    }
}
