using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.DTOs
{
    public class ScoreTypeDto
    {
        [Required]
        public string? ScoreTypeName { get; set; }
        [Required]
        public int ScoreScale { get; set; }
    }
}
