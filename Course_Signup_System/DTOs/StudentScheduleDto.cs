namespace Course_Signup_System.DTOs
{
    public class StudentScheduleDto
    {
        public string? Class { get; set; }
        public string? Time { get; set; }
        public string? Day { get; set; }
        public string? Period { get; set; }

        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
