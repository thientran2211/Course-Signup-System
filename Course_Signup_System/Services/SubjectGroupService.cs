using Course_Signup_System.Data;
using Course_Signup_System.DTOs;
using Course_Signup_System.Interfaces;
using Course_Signup_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Signup_System.Services
{
    public class SubjectGroupService : ISubjectGroupService
    {
        private readonly CourseSignupContext _context;
        public SubjectGroupService(CourseSignupContext context) 
        {
            _context = context;
        }

        public async Task<List<SubjectGroup>> GetSubjectGroupsAsync()
        {
            try
            {
                var subjectGroups = await _context.SubjectGroups.ToListAsync();
                return subjectGroups;
            }
            catch { throw new NotImplementedException("There is no subject group data."); }
        }

        public async Task<SubjectGroup> GetSubjectGroupByIdAsync(int id)
        {
            try
            {
                var subjectGroup = await _context.SubjectGroups.FindAsync(id)
                    ?? throw new Exception("There is no subject group of this id");
                return subjectGroup;
            }
            catch { throw new NotImplementedException(); }
        }

        public async Task<SubjectGroup> AddNewSubjectGroupAsync(SubjectGroupDto subjectGroupDto)
        {
            try
            {
                var subjectGroup = new SubjectGroup
                {
                    Name = subjectGroupDto.SubjectGroupName
                };
                _context.SubjectGroups.Add(subjectGroup);
                await _context.SaveChangesAsync();
                return subjectGroup;
            }
            catch { throw new Exception("Please check to correct information"); }
        }

        public async Task<SubjectGroup> UpdateSubjectGroupAsync(int id, SubjectGroupDto subjectGroupDto)
        {
            try
            {
                var subjectGroup = _context.SubjectGroups.Find(id)
                ?? throw new Exception("There is no subject group of this id");

                subjectGroup.Name = subjectGroupDto.SubjectGroupName;
                _context.SubjectGroups.Update(subjectGroup);
                await _context.SaveChangesAsync();
                return subjectGroup;
            }
            catch { throw new NotImplementedException("Update subject group failed"); }
            
        }

        public async Task DeleteSubjectGroupAsync(int id)
        {
            try
            {
                var subjectGroup = _context.SubjectGroups.Find(id)
                    ?? throw new Exception("There is no subject group of this id");
                _context.SubjectGroups.Remove(subjectGroup);
                await _context.SaveChangesAsync();
            }
            catch { throw new NotImplementedException("Delete subject group failed!"); }
        }
    }
}
