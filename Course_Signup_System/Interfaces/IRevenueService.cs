using Course_Signup_System.Responses;

namespace Course_Signup_System.Interfaces
{
    public interface IRevenueService
    {
        Task<List<GetStudentsHavePaidResponse>> GetStudentsHavePaidAsync();
        Task<List<GetLecturersSalaryResponse>> GetLecturersSalaryAsync();
    }
}
