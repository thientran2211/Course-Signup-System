﻿namespace Course_Signup_System.Models
{
    public class Lecturer
    {
        public int LecturerId { get; set; }
        public string? TaxCode { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set;}
        public DateTime? DateOfBirth { get; set; }
        public string? Sex { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? MainSubject { get; set; }
        public string? ConcurrentSubject { get; set; }
        public string? Image {  get; set; }

        public int RoleId { get; set; }

        public Role? Role { get; set; }

        public ICollection<LecturingSchedule>? LecturingSchedules { get; set; }
    }
}
