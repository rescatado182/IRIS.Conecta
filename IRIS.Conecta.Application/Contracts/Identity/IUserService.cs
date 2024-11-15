using IRIS.Conecta.Application.Models.Identity;

namespace IRIS.Conecta.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<Student> GetUser(string userId);

        Task<List<Student>> GetStudents();

        Task<List<Student>> GetManagers();
    }
}
