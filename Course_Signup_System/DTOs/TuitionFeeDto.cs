namespace Course_Signup_System.DTOs
{
    public class TuitionFeeDto
    {
        public int TuitionFee { get; set; }
        public string? TuitionType { get; set; }
        public int Discount { get; set; }
        public int Level { get; set; }
        public string? Note { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }
    }
}
