using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.AcademicData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.AcademicData.Queries.GetAcademicDataById
{
    public class GetAcademicDataByIdRequestHandler : IRequestHandler<GetAcademicDataByIdRequest, AcademicDataDto>
    {
        private readonly IMapper mapper;
        private readonly IAcademicDataRepository academicDataRepository;

        public GetAcademicDataByIdRequestHandler(IMapper mapper, IAcademicDataRepository academicDataRepository)
        {
            this.mapper = mapper;
            this.academicDataRepository = academicDataRepository;
        }
        public async Task<AcademicDataDto> Handle(GetAcademicDataByIdRequest request, CancellationToken cancellationToken)
        {
            var academicData = await this.academicDataRepository.GetByIdAsync(request.Id);

            return this.mapper.Map<AcademicDataDto>(academicData);
        }
    }
}
