using IRIS.Conecta.Application.Features.PersonalData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.PersonalData.Commands.CreatePersonalData
{
    public class CreatePersonalDataCommand : IRequest<int>
    {
        public required PersonalDataDto PersonalDataDto { get; set; }
    }
}
