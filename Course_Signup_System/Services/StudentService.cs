using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Course_Signup_System.Services
{
    public class StudentService : IStudentService
    {
        private readonly CourseSignupContext _context;

        public StudentService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<Student> CreateStudentAsync(StudentDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var student = new Student
            {
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                DateOfBirth = dto.DateOfBirth,
                Sex = dto.Sex,
                Email = dto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Phone = dto.Phone,
                Address = dto.Address,
                ParentName = dto.ParentName,
                ClassId = dto.ClassId,
                CourseId = dto.CourseId,
                RoleId = dto.RoleId,
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.StudentId == id)
                ?? throw new Exception($"Student of {id} doesn't exist!");
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id)
                ?? throw new Exception($"Student of {id} doesn't exist!");
            return student;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            var students = await _context.Students.ToListAsync()
                ?? throw new Exception("There is no student data!");
            return students;          
        }

        public async Task<Student> UpdateStudentAsync(int id, StudentDto dto)
        {
            var student = await GetStudentAsync(id);

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            student.LastName = dto.LastName;
            student.FirstName = dto.FirstName;
            student.DateOfBirth = dto.DateOfBirth;
            student.Sex = dto.Sex;
            student.Email = dto.Email;
            student.PasswordHash = passwordHash;
            student.PasswordSalt = passwordSalt;
            student.Phone = dto.Phone;
            student.Address = dto.Address;
            student.ParentName = dto.ParentName;
            student.ClassId = dto.ClassId;
            student.CourseId = dto.CourseId;
            student.RoleId = dto.RoleId;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UploadStudentImageAsync(int id, IFormFile file)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id)
                ?? throw new Exception("Student doesn't exist!");
            if (file != null)
            {
                var validExtensions = new[] { ".jpg", ".jpeg", ".png", "webp" };
                var extension = Path.GetExtension(file.FileName).ToLower();

                if (!validExtensions.Contains(extension))
                {
                    throw new Exception("Invalid file format!");
                }

                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                var fileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                student.Image = filePath;
                await _context.SaveChangesAsync();
            }

            return student;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
