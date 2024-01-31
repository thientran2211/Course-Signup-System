using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class LecturingScheduleService : ILecturingScheduleService
    {
        private readonly CourseSignupContext _context;

        public LecturingScheduleService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<LecturingSchedule> CreateLecturingScheduleAsync(LecturingScheduleDto dto)
        {
            var lecturer = await _context.Lecturers.FindAsync(dto.LecturerId)
                ?? throw new Exception("Lecturer not found!");

            var lecturingSchedule = new LecturingSchedule
            {
                Classroom = dto.Classroom,
                TimeStart = dto.TimeStart,
                TimeEnd = dto.TimeEnd,
                TeachingDay = dto.TeachingDay,
                ClassId = dto.ClassId,
                SubjectId = dto.SubjectId,
                LecturerId = dto.LecturerId
            };

            _context.LecturingSchedules.Add(lecturingSchedule);
            await _context.SaveChangesAsync();
            return lecturingSchedule;
        }

        public async Task DeleteLecturingScheduleAsync(int id)
        {
            var lecturingSchedule = await _context.LecturingSchedules.SingleOrDefaultAsync(l => l.Id == id)
                ?? throw new Exception("lecturing schedule doesn't exist!");
            _context.LecturingSchedules.Remove(lecturingSchedule);
            await _context.SaveChangesAsync();

        }

        public async Task<LecturingSchedule> GetLecturingScheduleAsync(int id)
        {
            var lecturingSchedule = await _context.LecturingSchedules.FindAsync(id)
                ?? throw new Exception("lecturing schedule doesn't exist!");
            return lecturingSchedule;

        }

        public async Task<List<LecturingSchedule>> GetLecturingSchedulesAsync()
        {
            var lecturingSchedules = await _context.LecturingSchedules.ToListAsync();
            return lecturingSchedules;
        }

        public async Task<LecturingSchedule> UpdateLecturingScheduleAsync(int id, LecturingScheduleDto dto)
        {
            var lecturingSchedule = await GetLecturingScheduleAsync(id);

            lecturingSchedule.Classroom = dto.Classroom;
            lecturingSchedule.TimeStart = dto.TimeStart;
            lecturingSchedule.TimeEnd = dto.TimeEnd;
            lecturingSchedule.TeachingDay = dto.TeachingDay;
            lecturingSchedule.ClassId = dto.ClassId;
            lecturingSchedule.SubjectId = dto.SubjectId;
            lecturingSchedule.LecturerId = dto.LecturerId;

            _context.LecturingSchedules.Update(lecturingSchedule);
            await _context.SaveChangesAsync();
            return lecturingSchedule;
        }
    }
}
