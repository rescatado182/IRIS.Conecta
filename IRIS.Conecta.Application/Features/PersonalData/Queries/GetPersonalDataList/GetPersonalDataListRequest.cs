using IRIS.Conecta.Application.Features.PersonalData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.PersonalData.Queries.GetPersonalDataList
{
    public class GetPersonalDataListRequest : IRequest<List<PersonalDataListDto>>
    {
    }
}
