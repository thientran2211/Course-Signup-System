using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class TuitionFeeService : ITuitionFeeService
    {
        private readonly CourseSignupContext _context;

        public TuitionFeeService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<TuitionFee> CreateTuitionAsync(TuitionFeeDto dto)
        {
            var tuition = new TuitionFee
            {
                AmountTuition = dto.TuitionFee,
                Type = dto.TuitionType,
                Discount = dto.Discount,
                Level = dto.Level,
                Note = dto.Note,
                TotalTuition = (dto.TuitionFee) - (dto.Discount / 100 * dto.TuitionFee),
                ClassId = dto.ClassId,
                StudentId = dto.StudentId,
            };
            _context.TuitionFees.Add(tuition);
            await _context.SaveChangesAsync();
            return tuition;
        }

        public async Task DeleteTuitionAsync(int id)
        {
            var tuition = await _context.TuitionFees.SingleOrDefaultAsync(t => t.Id == id)
                ?? throw new Exception($"tuition of {id} does not exist");
            _context.TuitionFees.Remove(tuition);
            await _context.SaveChangesAsync();

        }

        public async Task<TuitionFee> GetTuitionByIdAsync(int id)
        {
            var tuition = await _context.TuitionFees.FindAsync(id)
                ?? throw new Exception($"tuition of {id} does not exist");
            return tuition;
        }

        public async Task<List<TuitionFee>> GetTuitionFeesAsync()
        {
            var tuitions = await _context.TuitionFees.ToListAsync();
            return tuitions;
        }

        public async Task<TuitionFee> UpdateTuitionAsync(int id, TuitionFeeDto dto)
        {
            var tuitionFee = await GetTuitionByIdAsync(id);
            tuitionFee.AmountTuition = dto.TuitionFee;
            tuitionFee.Type = dto.TuitionType;
            tuitionFee.Discount = dto.Discount;
            tuitionFee.Note = dto.Note;
            tuitionFee.TotalTuition = (dto.TuitionFee) - (dto.Discount / 100 * dto.TuitionFee);
            tuitionFee.ClassId = dto.ClassId;
            tuitionFee.StudentId = dto.StudentId;

            _context.TuitionFees.Update(tuitionFee);
            await _context.SaveChangesAsync();
            return tuitionFee;
        }
    }
}
