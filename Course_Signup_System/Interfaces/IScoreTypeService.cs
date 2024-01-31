using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface IScoreTypeService
    {
        Task<List<ScoreType>> GetScoreTypesAsync();
        Task<ScoreType> GetScoreTypeAsync(int id);
        Task<ScoreType> CreateScoreTypeAsync(ScoreTypeDto dto);
        Task<ScoreType> UpdateScoreTypeAsync(int id, ScoreTypeDto dto);
        Task DeleteScoreTypeAsync(int id);
    }
}
