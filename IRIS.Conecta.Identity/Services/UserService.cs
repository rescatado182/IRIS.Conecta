using IRIS.Conecta.Application.Contracts.Identity;
using IRIS.Conecta.Application.Models.Identity;
using IRIS.Conecta.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IRIS.Conecta.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Student> GetUser(string userId)
        {
            var student = await _userManager.FindByIdAsync(userId);

            return new Student
            {
                Id          = student.Id,
                Username    = student.UserName,
                Email       = student.Email,                
                FirstName   = student.FirstName,
                LastName    = student.LastName
            };
        }

        public async Task<List<Student>> GetStudents()
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");

            return students.Select(q => new Student
            {
                Id          = q.Id,
                Username    = q.UserName,
                Email       = q.Email,
                FirstName   = q.FirstName,
                LastName    = q.LastName
            }).ToList();
        }

        public async Task<List<Student>> GetManagers()
        {
            List<Student> users = [];

            var admins = await _userManager.GetUsersInRoleAsync("Administrator");            
            var assistants = await _userManager.GetUsersInRoleAsync("Assistant");
            var heads = await _userManager.GetUsersInRoleAsync("HEAD_OF_DEPARTMENT");

            var AdminList = admins.Select(q => new Student
            {
                Id = q.Id,
                Username = q.UserName,
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName
            }).ToList();

            var AssistantList = assistants.Select(q => new Student
            {
                Id = q.Id,
                Username = q.UserName,
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName
            }).ToList();

            var HeadList = heads.Select(q => new Student
            {
                Id = q.Id,
                Username = q.UserName,
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName
            }).ToList();

            users.AddRange(AdminList);
            users.AddRange(AssistantList);
            users.AddRange(HeadList);

            return users;
        }
         

    }
}
