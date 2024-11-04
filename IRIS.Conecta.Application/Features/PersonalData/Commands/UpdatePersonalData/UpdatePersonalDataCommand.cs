using IRIS.Conecta.Application.Features.PersonalData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.PersonalData.Commands.UpdatePersonalData
{
    public class UpdatePersonalDataCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public required PersonalDataDto PersonalDataDto { get; set; }
    }
}
