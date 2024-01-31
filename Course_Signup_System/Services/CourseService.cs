using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class CourseService : ICourseService
    {
        private readonly CourseSignupContext _context;

        public CourseService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<Course> AddNewCourseAsync(CourseDto courseDto)
        {
            var course = new Course
            {
                CourseName = courseDto.CourseName
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id)
                ?? throw new Exception("Course not found!");

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id)
                ?? throw new Exception($"Could not find course of this {id}");
            return course;
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses;
        }

        public async Task<Course> UpdateCourseAsync(int id, CourseDto courseDto)
        {
            var course = _context.Courses.Find(id)
                ?? throw new Exception($"Could not find course of this {id}");

            course.CourseName = courseDto.CourseName;
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            return course;
        }
    }
}
