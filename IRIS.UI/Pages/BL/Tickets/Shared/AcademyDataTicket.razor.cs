using ApexCharts;
using IRIS.Frontend.Repositories;
using IRIS.UI.Data;
using IRIS.UI.Interfaces;
using IRIS.UI.Models;
using IRIS.UI.Models.List;
using IRIS.UI.Models.Save;
using IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility;
using IRIS.UI.Pages.Masters.BL.RequestTypes;
using IRIS.UI.Services.BL;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace IRIS.UI.Pages.BL.Tickets.Shared
{
    public partial class AcademyDataTicket : ComponentBase, IValidateData
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] TicketMovilityRequest MovilityRequestState { get; set; }

        private bool isChecked;

        private FacultyVM selectedFaculty;
        private ProgramVM selectedProgram;

        private EnumProgramType selectedProgramType;
        private List<EnumProgramType> enumProgramType = new List<EnumProgramType>();

        private List<FacultyVM> faculties = new List<FacultyVM>();

        private AcademyDataVM academyData = new AcademyDataVM();

        private List<ProgramVM> programs = new List<ProgramVM>();

        




        protected override async Task OnInitializedAsync()
        {
            enumProgramType = Enum.GetValues(typeof(EnumProgramType)).Cast<EnumProgramType>().ToList();
            await ListAsyncFaculties();
            programs = SampleData.GetPrograms();
        }

        public async Task<int> UpdateTicketAcademyDataAsync(int? idTicket, AcademyDataVM academyData, int academicDataId, string userId)
        {
            var updatedAcademicData = CreateUpdatedAcademicData(idTicket, academyData, academicDataId, userId);

            LogJsonPayload(updatedAcademicData);

            var responseHttp = academicDataId > 0
                ? await Repository.PutAsync("/api/academicData", updatedAcademicData)
                : await Repository.PostAsync("/api/academicData", updatedAcademicData);

            if (responseHttp.Error)
            {
                await LogAndShowErrorAsync(responseHttp);
                return 0;
            }

            return await GetUpdatedEntityIdAsync(responseHttp) ?? 0;
        }

        private AcademyDataSaveVM CreateUpdatedAcademicData(int? idTicket, AcademyDataVM academyData, int academicDataId, string userId)
        {
            return new AcademyDataSaveVM
            {
                id = academicDataId,
                academicDataDto = new AcademyDataSaveVM.AcademicDataDto
                {
                    TicketId = idTicket.Value,
                    ProgramId = MovilityRequestState.academyData.ProgramId,
                    ResearchProject = MovilityRequestState.academyData.ResearchProject,
                    ResearchGroup = MovilityRequestState.academyData.ResearchGroup,
                    ProgramType = (EnumProgramType)MovilityRequestState.academyData.ProgramType,
                    AverageCredit = MovilityRequestState.academyData.AverageCredit,
                    EnrolledSemester = MovilityRequestState.academyData.EnrolledSemester,
                    IsInstitutionalGroup = MovilityRequestState.academyData.IsInstitutionalGroup,
                    UserId = userId
                }
            };
        }

        private void LogJsonPayload(object data)
        {
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonString);
        }

        private async Task LogAndShowErrorAsync(HttpResponseWrapper<object> responseHttp)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Console.WriteLine(message);
        }

        private async Task<int?> GetUpdatedEntityIdAsync(HttpResponseWrapper<object> responseHttp)
        {
            var resultContent = await responseHttp.HttpResponseMessage.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(resultContent)) return null;

            using var jsonDocument = JsonDocument.Parse(resultContent);
            return jsonDocument.RootElement.TryGetProperty("id", out var idElement)
                ? idElement.GetInt32()
                : (int?)null;
        }

        private async Task<IEnumerable<FacultyVM>> SearchFaculties(string searchText)
        {
            return faculties.Where(f => f.FacultyName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }
        private async Task<IEnumerable<ProgramVM>> SearchPrograms(string searchText)
        {
            return programs.Where(s => s.FacultyId == MovilityRequestState.academyData.FacultyId && s.ProgramName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }
        private async Task OnItemSelected<T>(T selectedItem)
        {
            if (selectedItem is FacultyVM faculty)
            {
                MovilityRequestState.academyData.Faculties = faculty;
                MovilityRequestState.academyData.FacultyId = faculty.Id;
            }
            if (selectedItem is ProgramVM program)
            {
                MovilityRequestState.academyData.Program = program;
                MovilityRequestState.academyData.ProgramId = program.Id;
            }


        }

        //public IEnumerable<ValidationResult> ValidateAcademyDataAsync()
        //{
        //    var results = new List<ValidationResult>();
        //    var validationContext = new ValidationContext(MovilityRequestState.personalData, null, null);
        //    Validator.TryValidateObject(MovilityRequestState.personalData, validationContext, results, true);

        //    if (MovilityRequestState.personalData is IValidatableObject validatableModel)
        //        results.AddRange(validatableModel.Validate(validationContext));

        //    foreach (var validationResult in results)
        //    {
        //        Console.WriteLine(validationResult.ErrorMessage);
        //    }

        //    return results;
        //}

        public Task<IEnumerable<ValidationResult>> ValidateDataAsync()
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(MovilityRequestState.academyData, null, null);
            Validator.TryValidateObject(MovilityRequestState.academyData, validationContext, results, true);

            if (MovilityRequestState.academyData is IValidatableObject validatableModel)
                results.AddRange(validatableModel.Validate(validationContext));

            foreach (var validationResult in results)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }

            return Task.FromResult<IEnumerable<ValidationResult>>(results);
        }
        private async Task<bool> ListAsyncFaculties()
        {


            var responseHttp = await Repository.GetAsync<List<FacultyVM>>("/api/Faculties");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();


                return false;
            }
            faculties = responseHttp.Response;
            return true;
        }
    }
}