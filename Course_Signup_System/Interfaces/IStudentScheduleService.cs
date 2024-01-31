using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface IStudentScheduleService
    {
        Task<List<StudentSchedule>> GetStudentSchedulesAsync();
        Task<StudentSchedule> GetStudentScheduleAsync(int id);
        Task<StudentSchedule> CreateStudentScheduleAsync(StudentScheduleDto dto);
        Task<StudentSchedule> UpdateStudentScheduleAsync(int id, StudentScheduleDto dto);
        Task DeleteStudentScheduleAsync(int id);
    }
}
