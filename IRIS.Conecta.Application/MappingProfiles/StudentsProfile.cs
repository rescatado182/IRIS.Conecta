using AutoMapper;
using IRIS.Conecta.Application.Models.Identity;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, Student>();
            CreateMap<Student, List<Student>>();
        }
    }
}
