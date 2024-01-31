namespace Course_Signup_System.Responses
{
    public class GetLecturersSalaryResponse
    {
        public int LecturerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public decimal? TotalSalary { get; set; }
    }
}
