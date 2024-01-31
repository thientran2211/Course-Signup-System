using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface ILecturingScheduleService
    {
        Task<List<LecturingSchedule>> GetLecturingSchedulesAsync();
        Task<LecturingSchedule> GetLecturingScheduleAsync(int id);
        Task<LecturingSchedule> CreateLecturingScheduleAsync(LecturingScheduleDto dto);
        Task<LecturingSchedule> UpdateLecturingScheduleAsync(int id, LecturingScheduleDto dto);
        Task DeleteLecturingScheduleAsync(int id);
    }
}
