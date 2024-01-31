using Course_Signup_System.DTOs;
using Course_Signup_System.Models;
using Course_Signup_System.Responses;

namespace Course_Signup_System.Interfaces
{
    public interface IClassService
    {
        Task<List<Class>> GetClassesAsync();
        Task<Class> GetClassAsync(int id);
        Task<List<GetStudentsInClassResponse>> GetStudentsInClassAsync(int id);
        Task<Class> CreateClassAsync(ClassDto dto);
        Task<Class> UploadClassImageAsync(int id, IFormFile file);
        Task<Class> UpdateClassAsync(int id, ClassDto dto);
        Task DeleteClassAsync(int id);
    }
}
