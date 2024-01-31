using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(int id);
        Task<Student> CreateStudentAsync(StudentDto dto);
        Task<Student> UploadStudentImageAsync(int id, IFormFile file);
        Task<Student> UpdateStudentAsync(int id, StudentDto dto);
        Task DeleteStudentAsync(int id);
    }
}
