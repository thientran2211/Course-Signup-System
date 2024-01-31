using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class StudentScheduleService : IStudentScheduleService
    {
        private readonly CourseSignupContext _context;

        public StudentScheduleService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<StudentSchedule> CreateStudentScheduleAsync(StudentScheduleDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var student = await _context.Students
                .Include(s => s.Class)
                .FirstOrDefaultAsync(s => s.StudentId == dto.StudentId)
                ?? throw new Exception("Student doesn't exist!");

            var studentSchedule = new StudentSchedule
            {
                Class = dto.Class,
                Time = dto.Time,
                Day = dto.Day,
                Period = dto.Period,
                StudentId = dto.StudentId,
                SubjectId = dto.SubjectId
            };
            _context.StudentSchedules.Add(studentSchedule);
            await _context.SaveChangesAsync();
            return studentSchedule;
        }

        public async Task DeleteStudentScheduleAsync(int id)
        {
            var studentSchedule = await GetStudentScheduleAsync(id);
            _context.StudentSchedules.Remove(studentSchedule);
            await _context.SaveChangesAsync();
        }

        public async Task<StudentSchedule> GetStudentScheduleAsync(int id)
        {
            var studentSchedule = await _context.StudentSchedules.FindAsync(id)
                ?? throw new Exception($"student schedule of {id} doesn't exist!");
            return studentSchedule;
        }

        public async Task<List<StudentSchedule>> GetStudentSchedulesAsync()
        {
            var studentSchedules = await _context.StudentSchedules.ToListAsync()
                ?? throw new Exception("There is no student schedule data");
            return studentSchedules;
        }

        public async Task<StudentSchedule> UpdateStudentScheduleAsync(int id, StudentScheduleDto dto)
        {
            var studentSchedule = await GetStudentScheduleAsync(id);

            var student = await _context.Students
                .Include(s => s.Class)
                .FirstOrDefaultAsync(s => s.StudentId == dto.StudentId)
                ?? throw new Exception("Student doesn't exist!");

            studentSchedule.Class = dto.Class;
            studentSchedule.Time = dto.Time;
            studentSchedule.Day = dto.Day;
            studentSchedule.Period = dto.Period;
            studentSchedule.StudentId = dto.StudentId;
            studentSchedule.SubjectId = dto.SubjectId;

            _context.StudentSchedules.Update(studentSchedule);
            await _context.SaveChangesAsync();
            return studentSchedule;
        }
    }
}
