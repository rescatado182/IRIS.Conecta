using IRIS.Conecta.Application.Features.AcademicData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.AcademicData.Commands.CreateAcademicData
{
    public class CreateAcademicDataCommand : IRequest<int>
    {
        public AcademicDataDto AcademicDataDto { get; set; }
    }
}
