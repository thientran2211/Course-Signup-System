using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.DTOs
{
    public class LecturingScheduleDto
    {
        public string? Classroom { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TimeStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TimeEnd { get; set; }
        public string? TeachingDay { get; set; }
        public int SubjectId { get; set; }
        public int LecturerId { get; set; }
        public int ClassId { get; set; }
    }
}
