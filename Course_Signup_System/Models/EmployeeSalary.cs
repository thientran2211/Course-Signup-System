namespace Course_Signup_System.Models
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public int SalaryPercent { get; set; }
        public int Allowance { get; set; }
        public decimal TotalSalary {  get; set; }

        public int LecturerId { get; set; }
        public int ClassId { get; set; }
    }
}
