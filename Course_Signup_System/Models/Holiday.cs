namespace Course_Signup_System.Models
{
    public class Holiday
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Reason { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set;}
    }
}
