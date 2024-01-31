using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface ITuitionFeeService
    {
        Task<List<TuitionFee>> GetTuitionFeesAsync();

        Task<TuitionFee> GetTuitionByIdAsync(int id);

        Task<TuitionFee> CreateTuitionAsync(TuitionFeeDto dto);

        Task<TuitionFee> UpdateTuitionAsync(int id, TuitionFeeDto dto);

        Task DeleteTuitionAsync(int id);
    }
}
