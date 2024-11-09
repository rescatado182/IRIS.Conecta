using IRIS.Conecta.Application.Features.AcademicData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.AcademicData.Queries.GetAcademicDataList
{
    public class GetAcademicDataListRequest : IRequest<List<AcademicDataListDto>>
    {
    }
}
