using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface ISubjectGroupService
    {
        Task<List<SubjectGroup>> GetSubjectGroupsAsync();
        Task<SubjectGroup> GetSubjectGroupByIdAsync(int id);
        Task<SubjectGroup> AddNewSubjectGroupAsync(SubjectGroupDto subjectGroupDto);
        Task<SubjectGroup> UpdateSubjectGroupAsync(int id, SubjectGroupDto subjectGroupDto);
        Task DeleteSubjectGroupAsync(int id);
    }
}
