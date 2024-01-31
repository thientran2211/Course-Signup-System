using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly CourseSignupContext _context;
        public HolidayService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<Holiday> AddNewHolidayAsync(HolidaysDto dto)
        {
            var holiday = new Holiday
            {
                Name = dto.Name,
                Reason = dto.Reason,
                TimeStart = dto.TimeStart,
                TimeEnd = dto.TimeEnd
            };

            _context.Holidays.Add(holiday);
            await _context.SaveChangesAsync();
            return holiday;
        }

        public async Task<List<Holiday>> GetHolidaysAsync()
        {
            var holidays = await _context.Holidays.ToListAsync();
            return holidays;
        }

        public async Task RemoveHolidayAsync(Guid id)
        {
            var holiday = _context.Holidays.Find(id)
                ?? throw new Exception($"{id} isn't exist for any holiday!");
            _context.Holidays.Remove(holiday);
            await _context.SaveChangesAsync();
        }

        public async Task<Holiday> UpdateHolidayAsync(Guid id ,HolidaysDto dto)
        {
            var holiday = _context.Holidays.Find(id)
                ?? throw new Exception($"{id} isn't exist for any holiday!");

            holiday.Name = dto.Name;
            holiday.Reason = dto.Reason;
            holiday.TimeStart = dto.TimeStart;
            holiday.TimeEnd = dto.TimeEnd;
            

            _context.Holidays.Update(holiday);
            await _context.SaveChangesAsync();
            return holiday;
        }
    }
}
