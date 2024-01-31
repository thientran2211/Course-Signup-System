using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface IHolidayService
    {
        Task<List<Holiday>> GetHolidaysAsync();
        Task<Holiday> AddNewHolidayAsync(HolidaysDto dto);
        Task<Holiday> UpdateHolidayAsync(Guid id, HolidaysDto dto);
        Task RemoveHolidayAsync(Guid id);
    }
}
