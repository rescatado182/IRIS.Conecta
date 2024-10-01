using AutoMapper;
using IRIS.Conecta.Application.Features.RequestTypes.Commands.CreateRequestType;
using IRIS.Conecta.Application.Features.RequestTypes.Commands.UpdateRequestType;
using IRIS.Conecta.Application.Features.RequestTypes.Dtos;
using IRIS.Conecta.Domain.Entities.Masters;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class RequestTypesProfile : Profile
    {
        public RequestTypesProfile()
        {
            CreateMap<RequestType, RequestTypesDto>().ReverseMap();
            CreateMap<RequestType, RequestTypesListDto>();
            CreateMap<CreateRequestTypeCommand, RequestType>();
            CreateMap<UpdateRequestTypeCommand, RequestType>();

        }
    }
}
