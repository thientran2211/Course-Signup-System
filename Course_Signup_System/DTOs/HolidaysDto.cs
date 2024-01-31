using System.ComponentModel.DataAnnotations;

namespace Course_Signup_System.DTOs
{
    public class HolidaysDto
    {
        public string? Name { get; set; }
        public string? Reason { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TimeStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TimeEnd { get; set; }
    }
}
