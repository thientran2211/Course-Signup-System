using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface ILecturerService
    {
        Task<List<Lecturer>> GetLecturersAsync();
        Task<Lecturer> GetLecturerAsync(int id);
        Task<Lecturer> CreateLecturerAsync(LecturerDto dto);
        Task<Lecturer> UploadLecturerImageAsync(int id, IFormFile file);
        Task<Lecturer> UpdateLecturerAsync(int id, LecturerDto dto);
        Task DeleteLecturerAsync(int id);
    }
}
