using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetSubjectsAsync();
        Task<Subject> CreateSubjectAsync(SubjectDto dto);
        Task<Subject> UpdateSubjectAsync(int id, SubjectDto dto);
        Task DeleteSubjectAsync(int id);
    }
}
