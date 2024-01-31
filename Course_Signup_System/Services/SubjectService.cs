using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly CourseSignupContext _context;

        public SubjectService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<Subject> CreateSubjectAsync(SubjectDto dto)
        {
            var subject = new Subject
            {
                SubjectCode = dto.SubjectCode,
                SubjectName = dto.SubjectName,
                SubjectGroupId = dto.SubjectGroupId,
                DepartmentId = dto.DepartmentId,
            };

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id)
                ?? throw new Exception($"There is no data of {id}");
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Subject>> GetSubjectsAsync()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return subjects;
        }

        public async Task<Subject> UpdateSubjectAsync(int id, SubjectDto dto)
        {
            var subject = await _context.Subjects.FindAsync(id)
                ?? throw new Exception($"There is no data of {id}");

            subject.SubjectCode = dto.SubjectCode;
            subject.SubjectName = dto.SubjectName;
            subject.SubjectGroupId = dto.SubjectGroupId;
            subject.DepartmentId = dto.DepartmentId;

            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();

            return subject;
        }
    }
}
