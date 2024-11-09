using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.AcademicData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.AcademicData.Queries.GetAcademicDataList
{
    public class GetAcademicDataListRequestHandler : IRequestHandler<GetAcademicDataListRequest, List<AcademicDataListDto>>
    {
        private readonly IMapper mapper;
        private readonly IAcademicDataRepository academicDataRepository;

        public GetAcademicDataListRequestHandler(IMapper mapper, IAcademicDataRepository academicDataRepository)
        {
            this.mapper = mapper;
            this.academicDataRepository = academicDataRepository;
        }
        public async Task<List<AcademicDataListDto>> Handle(GetAcademicDataListRequest request, CancellationToken cancellationToken)
        {
            // Query Data
            var academicData = await this.academicDataRepository.GetAsync();

            // Mapping data
            var data = this.mapper.Map<List<AcademicDataListDto>>(academicData);

            return data;
        }
    }
}
