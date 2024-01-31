using Course_Signup_System.Data;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Responses;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class RevenueService : IRevenueService
    {
        private readonly CourseSignupContext _context;

        public RevenueService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<List<GetLecturersSalaryResponse>> GetLecturersSalaryAsync()
        {
            var lecturer = await _context.Lecturers
                .Where(l => _context.EmployeeSalarys.Any(e => e.LecturerId == l.LecturerId))
                .Select(l => new GetLecturersSalaryResponse
                {
                    LecturerId = l.LecturerId,
                    Name = $"{l.LastName} {l.FirstName}",
                    Email = l.Email,
                    Phone = l.Phone,
                    TotalSalary = _context.EmployeeSalarys
                                    .Where(e => e.LecturerId == l.LecturerId)
                                    .Select(e => e.TotalSalary)
                                    .FirstOrDefault()
                }).ToListAsync();

            return lecturer;
        }

        public async Task<List<GetStudentsHavePaidResponse>> GetStudentsHavePaidAsync()
        {
            var students = await _context.Students
                .Where(s => _context.TuitionFees.Any(t => t.StudentId == s.StudentId))
                .Select(s => new GetStudentsHavePaidResponse
                {
                    StudentId = s.StudentId,
                    Image = s.Image,
                    Name = $"{s.LastName} {s.FirstName}",
                    NameOfParent = s.ParentName,
                    DateOfBirth = s.DateOfBirth,
                    Address = s.Address,
                    Phone = s.Phone,
                    Email = s.Email,
                    ClassName = s.Class.ClassName
                }).ToListAsync();

            return students;
        }
    }
}
