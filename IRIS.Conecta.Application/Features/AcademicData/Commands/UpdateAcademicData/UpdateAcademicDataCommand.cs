using IRIS.Conecta.Application.Features.AcademicData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.AcademicData.Commands.UpdateAcademicData
{
    public class UpdateAcademicDataCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public AcademicDataDto AcademicDataDto { get; set; }
    }
}
