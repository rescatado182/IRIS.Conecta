using AutoMapper;
using IRIS.Conecta.Application.Features.Departments.Commands.CreateDepartment;
using IRIS.Conecta.Application.Features.Departments.Commands.UpdateDepartment;
using IRIS.Conecta.Application.Features.Departments.DTOs;
using IRIS.Conecta.Domain.Entities.Masters;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class DepartmentsProfile : Profile
    {
        public DepartmentsProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentsListDto>();
            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<UpdateDepartmentCommand, Department>();
        }

    }
}
