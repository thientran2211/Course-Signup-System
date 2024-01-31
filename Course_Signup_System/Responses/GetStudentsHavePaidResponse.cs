namespace Course_Signup_System.Responses
{
    public class GetStudentsHavePaidResponse
    {
        public int StudentId { get; set; }

        public string? Image { get; set; }

        public string? Name { get; set; }

        public string? NameOfParent { get; set; }

        public string? Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? ClassName { get; set; }
    }
}
