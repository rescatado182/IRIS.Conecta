using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Domain.Entities.Masters;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IRIS.Conecta.Persistence.Repositories
{
    public class FacultiesRepository(IRISConectaDatabaseContext context) : 
        GenericRepository<Faculty>(context), IFacultyRepository
    {

        //public async Task<Faculty> UpdateFacultyAsync(Faculty faculty)
        //{
        //    var entity = await _context.Set<Faculty>()
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(e => e.Id == faculty.Id);

        //    _context.Entry(faculty).State = EntityState.Detached;

        //    _context.ChangeTracker.Clear();

        //    _context.Entry(entity).CurrentValues.SetValues(faculty);
        //    _context.Update(entity);

        //    await _context.SaveChangesAsync();

        //    return faculty;
        //}
        
    }
}
