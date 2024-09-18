using AutoMapper;
using IRIS.Conecta.Application.Features.Departments.DTOs;
using IRIS.Conecta.Domain.Entities.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class DepartmentsProfile : Profile
    {
        public DepartmentsProfile()
        {
            CreateMap<Department, DepartmentsDto>().ReverseMap();
            CreateMap<Department, DepartmentsListDto>();

        }

    }
}
