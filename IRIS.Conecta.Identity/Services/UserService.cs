using IRIS.Conecta.Application.Contracts.Identity;
using IRIS.Conecta.Application.Models.Identity;
using IRIS.Conecta.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace IRIS.Conecta.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Student> GetStudent(string userId)
        {
            var student = await _userManager.FindByIdAsync(userId);

            return new Student
            {
                Email       = student.Email,
                Id          = student.Id,
                FirstName   = student.FirstName,
                LastName    = student.LastName
            };
        }

        public async Task<List<Student>> GetStudents()
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");

            return students.Select(q => new Student
            {
                Id = q.Id,
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName
            }).ToList();
        }
    }
}
