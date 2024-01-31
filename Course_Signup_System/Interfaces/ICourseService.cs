using Course_Signup_System.DTOs;
using Course_Signup_System.Models;

namespace Course_Signup_System.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task<Course> AddNewCourseAsync(CourseDto courseDto);
        Task<Course> UpdateCourseAsync(int id, CourseDto courseDto);
        Task DeleteCourseAsync(int id);
    }
}
