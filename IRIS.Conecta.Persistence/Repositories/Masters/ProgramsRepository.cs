using IRIS.Conecta.Application.Contracts.Persistence.Masters;
using IRIS.Conecta.Domain.Entities.Masters;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IRIS.Conecta.Persistence.Repositories.Masters
{
    public class ProgramsRepository(IRISConectaDatabaseContext context) :
        GenericRepository<Program>(context), IProgramRepository
    {
        public async Task<List<Program>> GetProgramswithDetails()
        {
            var programs = await _context.Programs
                .Include(q => q.Department)
                .ToListAsync();

            return programs;
        }

        public async Task<Program> GetProgramwithDetail(int id)
        {
            var program = await _context.Programs
                .Include(q => q.Department)
                .FirstOrDefaultAsync(q => q.Id == id);

            return program;
        }
    }
}
