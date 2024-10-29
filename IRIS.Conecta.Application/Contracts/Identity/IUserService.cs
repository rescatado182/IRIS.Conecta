using IRIS.Conecta.Application.Models.Identity;

namespace IRIS.Conecta.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Student>> GetStudents();

        Task<Student> GetStudent(string userId);
    }
}
