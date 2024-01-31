using Course_Signup_System.DTOs;
using Course_Signup_System.Models;
using Course_Signup_System.Responses;

namespace Course_Signup_System.Interfaces
{
    public interface ISubjectGradeTypeService
    {
        Task<List<SubjectGradeType>> GetSubjectGradeTypesAsync();
        Task<SubjectGradeType> GetSubjectGradeTypeAsync(int id);
        Task<SubjectGradeType> CreateSubjectGradeTypeAsync(SubjectGradeTypeDto dto);
        Task<SubjectGradeType> UpdateSubjectGradeTypeAsync(int id, SubjectGradeTypeDto dto);
        Task DeleteSubjectGradeTypeAsync(int id);
    }
}
