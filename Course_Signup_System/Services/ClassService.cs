using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Course_Signup_System.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Course_Signup_System.Services
{
    public class ClassService : IClassService
    {
        private readonly CourseSignupContext _context;

        public ClassService(CourseSignupContext context) 
        {
            _context = context;
        }

        public async Task<List<Class>> GetClassesAsync()
        {
            var classes = await _context.Classes.ToListAsync();
            if (classes.Count == 0)
            {
                throw new Exception("There is no class data!");
            }
            return classes;
        }

        public async Task<Class> GetClassAsync(int id)
        {
            var mClass = await _context.Classes.FindAsync(id)
                ?? throw new Exception($"Class of {id} doesn't exist!");
            return mClass;
        }

        public async Task<Class> CreateClassAsync(ClassDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var newClass = new Class
            {
                ClassCode = dto.ClassCode,
                ClassName = dto.ClassName,
                NumberOfStudent = dto.NumberOfStudent,
                Fee = dto.Fee,
                Description = dto.Description,
                DepartmentId = dto.DepartmentId,
            };
            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();
            return newClass;
        }
        
        public async Task<List<GetStudentsInClassResponse>> GetStudentsInClassAsync(int id)
        {
            var studentsInClass = await _context.Students
                .Where(s => s.ClassId == id)
                .ToListAsync();

            if (studentsInClass.Count == 0)
            {
                throw new Exception("student doesn't exist!");
            }    

            var statusTuition = await _context.TuitionFees
                .Where(t => t.ClassId == id)
                .Select(t => t.StudentId)
                .ToListAsync();

            var listOfStudent = studentsInClass.Select(s => new GetStudentsInClassResponse
            {
                Name = $"{s.LastName} {s.FirstName}",
                Email = s.Email,
                Phone = s.Phone,
                Status = statusTuition.Contains(s.StudentId) ? "Paid" : "Unpaid"
            }).ToList();

            return listOfStudent;
        }
     
        public async Task<Class> UploadClassImageAsync(int id, IFormFile file)
        {
            var mClass = await _context.Classes.FirstOrDefaultAsync(c => c.ClassId == id)
                ?? throw new Exception($"class of {id} doesn't exist!");

            if (file != null)
            {
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                var filePath = Path.Combine(uploadFolder, file.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                mClass.Image = filePath;
                await _context.SaveChangesAsync();
            }

            return mClass;
        }

        public async Task<Class> UpdateClassAsync(int id, ClassDto dto)
        {
            var existingClass = await _context.Classes.FindAsync(id)
                ?? throw new Exception($"Class of {id} doesn't exist!");

            existingClass.ClassCode = dto.ClassCode;
            existingClass.ClassName = dto.ClassName;
            existingClass.NumberOfStudent = dto.NumberOfStudent;
            existingClass.Fee = dto.Fee;
            existingClass.Description = dto.Description;
            existingClass.DepartmentId = dto.DepartmentId;

            _context.Classes.Update(existingClass);
            await _context.SaveChangesAsync();
            return existingClass;
        }

        public async Task DeleteClassAsync(int id)
        {
            var mClass = await _context.Classes.SingleOrDefaultAsync(c => c.ClassId == id)
                ?? throw new Exception($"Class of {id} does not exist!");

            _context.Classes.Remove(mClass);
            await _context.SaveChangesAsync();

        }
    }
}
