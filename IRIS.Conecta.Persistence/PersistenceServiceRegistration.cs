using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Contracts.Persistence.Masters;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Persistence.DatabaseContext;
using IRIS.Conecta.Persistence.Repositories;
using IRIS.Conecta.Persistence.Repositories.Masters;
using IRIS.Conecta.Persistence.Repositories.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IRIS.Conecta.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<IRISConectaDatabaseContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("IRISDatabaseConnectionString")
            ));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IFacultyRepository, FacultiesRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentsRepository>();
            services.AddScoped<IProgramRepository, ProgramsRepository>();

            services.AddScoped<IRequestTypeRepository, RequestTypesRepository>();

            services.AddScoped<ITicketsRepository, TicketsRepository>();
            services.AddScoped<ITicketsViewRepository, TicketsViewsRepository>();
            services.AddScoped<INotificationsRepository, NotificationsRepository>();

            services.AddScoped<IAcademicDataRepository, AcademicDataRepository>();
            services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();
            services.AddScoped<IPersonalDataViewRepository, PersonalDataViewRepository>();

            services.AddScoped<ITemplateResponsesRepository, TemplateResponsesRepository>();            

            return services;
        }
    }
}
