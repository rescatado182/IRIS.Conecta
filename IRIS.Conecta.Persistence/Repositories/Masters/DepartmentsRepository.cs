using IRIS.Conecta.Application.Contracts.Persistence.Masters;
using IRIS.Conecta.Domain.Entities.Masters;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IRIS.Conecta.Persistence.Repositories.Masters
{
    public class DepartmentsRepository(IRISConectaDatabaseContext context) :
        GenericRepository<Department>(context), IDepartmentRepository
    {
        public async Task<List<Department>> GetDepartmentsWithFaculties()
        {
            var departments = await _context.Departments
                .Include(q => q.Faculty)
                .ToListAsync();

            return departments;
        }

        public async Task<Department> GetDepartmentWithFaculty(int id)
        {
            var department = await _context.Departments
                .Include(q => q.Faculty)
                .FirstOrDefaultAsync(q => q.Id == id);

            return department;
        }
    }
}
