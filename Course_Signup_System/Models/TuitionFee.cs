namespace Course_Signup_System.Models
{
    public class TuitionFee
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int? Level { get; set; }
        public int? Discount { get; set; }
        public string? Note { get; set; }

        public int? ClassId { get; set; }
        public int? StudentId { get; set; }

        public Class? Class { get; set; }
        public Student? Student { get; set; }
    }
}
