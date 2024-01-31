using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Course_Signup_System.Models
{
    public class TuitionFee
    {
        public int Id { get; set; }
        public int AmountTuition { get; set; }
        public string? Type { get; set; }
        public int? Level { get; set; }
        public int? Discount { get; set; }
        public string? Note { get; set; }
        public decimal TotalTuition {  get; set; }

        public int ClassId { get; set; }
        public int StudentId { get; set; }

        [JsonIgnore]
        public Class? Class { get; set; }
        [JsonIgnore]
        public Student? Student { get; set; }
    }
}
