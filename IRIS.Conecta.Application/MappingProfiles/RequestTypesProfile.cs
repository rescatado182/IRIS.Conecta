using AutoMapper;
using IRIS.Conecta.Application.Features.RequestTypes.DTOs.RequestTypes;
using IRIS.Conecta.Domain.Entities.Masters;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class RequestTypesProfile : Profile
    {
        public RequestTypesProfile()
        {
            CreateMap<RequestType, RequestTypesDTO>().ReverseMap();
        }
    }
}
