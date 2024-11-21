using IRIS.Conecta.Application.Features.PersonalData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.PersonalData.Queries.GetPersonalDataById
{
    public class GetPersonalDataByIdRequest : IRequest<GetPersonalDataDto>
    {
        public int Id { get; set; }
    }
}
