using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Course_Signup_System.Responses;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class SubjectGradeTypeService : ISubjectGradeTypeService
    {
        private readonly CourseSignupContext _context;

        public SubjectGradeTypeService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<SubjectGradeType> CreateSubjectGradeTypeAsync(SubjectGradeTypeDto dto)
        {
            var subject = await _context.Subjects.FindAsync(dto.SubjectId)
                ?? throw new Exception("Subject not found!");
            var course = await _context.Courses
                .Where(c => c.CourseId == dto.CourseId)
                .FirstOrDefaultAsync() ?? throw new Exception("Course not found!");
            var scoreType = await _context.ScoreTypes.FindAsync(dto.ScoreTypeId)
                ?? throw new Exception("Score type not found!");

            var subjectGradeType = new SubjectGradeType
            {
                ScoreColumn = dto.ScoreColumn,
                RequiredScoreColumn = dto.RequiredScoreColumn,
                CourseId = dto.CourseId,
                SubjectId = dto.SubjectId,
                ScoreTypeId = dto.ScoreTypeId
            };
            _context.SubjectGradeTypes.Add(subjectGradeType);
            await _context.SaveChangesAsync();
            return subjectGradeType;
        }

        public async Task DeleteSubjectGradeTypeAsync(int id)
        {
            var subjectGradeType = await GetSubjectGradeTypeAsync(id);
            _context.SubjectGradeTypes.Remove(subjectGradeType);
            await _context.SaveChangesAsync();
        }

        public async Task<SubjectGradeType> GetSubjectGradeTypeAsync(int id)
        {
            var subjectGradeType = await _context.SubjectGradeTypes.FindAsync(id)
                ?? throw new Exception($"subject grade type of {id} doesn't exist!");
            return subjectGradeType;
        }

        public async Task<List<SubjectGradeType>> GetSubjectGradeTypesAsync()
        {
            var subjectGradeTypes = await _context.SubjectGradeTypes.ToListAsync()
                ?? throw new Exception("There is no subject grade type data!");
            return subjectGradeTypes;
        }
        
        public async Task<SubjectGradeType> UpdateSubjectGradeTypeAsync(int id, SubjectGradeTypeDto dto)
        {
            var subjectGradeType = await GetSubjectGradeTypeAsync(id);

            subjectGradeType.ScoreColumn = dto.ScoreColumn;
            subjectGradeType.RequiredScoreColumn = dto.RequiredScoreColumn;
            subjectGradeType.CourseId = dto.CourseId;
            subjectGradeType.SubjectId = dto.SubjectId;
            subjectGradeType.ScoreTypeId = dto.ScoreTypeId;
            _context.SubjectGradeTypes.Update(subjectGradeType);
            await _context.SaveChangesAsync();
            return subjectGradeType;
        }
    }
}
