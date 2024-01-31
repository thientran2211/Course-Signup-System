using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Course_Signup_System.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly CourseSignupContext _context;

        public LecturerService(CourseSignupContext context) 
        {
            _context = context;
        }
        public async Task<Lecturer> CreateLecturerAsync(LecturerDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var lecturer = new Lecturer
            {
                TaxCode = dto.TaxCode,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                DateOfBirth = dto.DateOfBirth,
                Sex = dto.Sex,
                Email = dto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Phone = dto.Phone,
                Address = dto.Address,
                MainSubject = dto.MainSubject,
                ConcurrentSubject = dto.ConcurrentSubject,
                RoleId = dto.RoleId
            };

            _context.Lecturers.Add(lecturer);
            await _context.SaveChangesAsync();
            return lecturer;
        }

        public async Task DeleteLecturerAsync(int id)
        {
            var lecturer = await _context.Lecturers.FindAsync(id)
                ?? throw new Exception($"lecturer of {id} doesn't exist!");

            _context.Lecturers.Remove(lecturer);
            await _context.SaveChangesAsync();
        }

        public async Task<Lecturer> GetLecturerAsync(int id)
        {
            var lecturer = await _context.Lecturers.FindAsync(id)
                ?? throw new Exception($"lecturer of {id} doesn't exist!");

            return lecturer;
        }

        public async Task<List<Lecturer>> GetLecturersAsync()
        {
            var lecturers = await _context.Lecturers.ToListAsync();
            return lecturers ?? throw new Exception("There is no lecturer data!");
        }

        public async Task<Lecturer> UpdateLecturerAsync(int id, LecturerDto dto)
        {
            var existingLecturer = await GetLecturerAsync(id);

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            existingLecturer.TaxCode = dto.TaxCode;
            existingLecturer.LastName = dto.LastName;
            existingLecturer.FirstName = dto.FirstName;
            existingLecturer.DateOfBirth = dto.DateOfBirth;
            existingLecturer.Sex = dto.Sex;
            existingLecturer.Email = dto.Email;
            existingLecturer.PasswordHash = passwordHash;
            existingLecturer.PasswordSalt = passwordSalt;
            existingLecturer.Phone = dto.Phone;
            existingLecturer.Address = dto.Address;
            existingLecturer.MainSubject = dto.MainSubject;
            existingLecturer.ConcurrentSubject = dto.ConcurrentSubject;
            existingLecturer.RoleId = dto.RoleId;

            _context.Lecturers.Update(existingLecturer);
            await _context.SaveChangesAsync();
            return existingLecturer;
        }

        public async Task<Lecturer> UploadLecturerImageAsync(int id, IFormFile file)
        {
            var lecturer = await _context.Lecturers.FirstOrDefaultAsync(l => l.LecturerId == id)
                ?? throw new Exception("Lecturer doesn't exist!");

            if (file != null)
            {
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                var filePath = Path.Combine(uploadFolder, file.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                lecturer.Image = filePath;
                await _context.SaveChangesAsync();
            }

            return lecturer;
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
