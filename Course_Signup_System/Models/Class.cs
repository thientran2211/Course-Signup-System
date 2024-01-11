namespace Course_Signup_System.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        public string? SchoolYear { get; set; }
        public int? NumberOfStudent {  get; set; }
        public string? State { get; set; }
        public int? Fee { get; set; }
        public string? Description { get; set; }
        public string? Image {  get; set; }

        public int DepartmentId { get; set; }


        public Department? Department { get; set; }
        public ICollection<Student>? Students { get; set; }

        
    }
}
