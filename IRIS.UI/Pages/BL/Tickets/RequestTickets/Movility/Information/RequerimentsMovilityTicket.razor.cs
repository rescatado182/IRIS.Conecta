using IRIS.UI.Data;
using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility.Information
{
    public partial class RequerimentsMovilityTicket : ComponentBase
    {
        private DateTimeOffset selectedInitialDate = DateTimeOffset.Now.AddDays(14).Date;
        private DateTimeOffset selectedFinalDate = DateTimeOffset.Now.AddDays(14).Date;

        private List<EnumRequirementsTypes> selectedRequirementTypes = new List<EnumRequirementsTypes>();
        private List<EnumRequirementsTypes> enumRequirementsTypes = new List<EnumRequirementsTypes>();



        protected override void OnInitialized()
        {
            enumRequirementsTypes = Enum.GetValues(typeof(EnumRequirementsTypes)).Cast<EnumRequirementsTypes>().ToList();
        }
        private string GetRequirementTypesDisplayName(EnumRequirementsTypes requirement)
        {
            return requirement.GetDisplayName();
        }


    }
}