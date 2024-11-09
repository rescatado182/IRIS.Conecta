using IRIS.Conecta.Application.Features.AcademicData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.AcademicData.Queries.GetAcademicDataById
{
    public class GetAcademicDataByIdRequest : IRequest<AcademicDataDto>
    {
        public int Id { get; set; }
    }
}
