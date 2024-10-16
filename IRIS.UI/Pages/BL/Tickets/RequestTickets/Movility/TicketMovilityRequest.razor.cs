using IRIS.UI.Pages.BL.Tickets.Shared;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using TabBlazor;
using TabBlazor.Components.Modals;
using TabBlazor.Services;

namespace IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility
{
    public partial class TicketMovilityRequest
    {

        [Inject] public IModalService Modal { get; set; }
        [Inject] public ToastService ToastService { get; set; }

        private bool isCompleted1 = false;
        private bool isCompleted2 = false;
        private bool isCompleted3 = false;

        private PersonalDataTicket personalDataRef;

        private TabsOrder tabsOrderRef;

        private int CurrentTabIndex { get; set; } = 5;

        private bool IsLastTab => tabsOrderRef?.IsLastTab ?? false;

        private async Task NextStepAsync()
        {
            bool isValid = true;

            // Validar Datos Personales
            if (personalDataRef != null)
            {
                isValid &= personalDataRef.ValidatePersonalData();
                //enviar msj de error por falta de campos
                if (isValid == false)
                {
                    await ToastService.AddToastAsync(new ToastModel { Title = "Formulario Incompleto", SubTitle = "", Message = "Por favor ingresa la información que tiene campos obligatorios" });
                    return;
                }
            }


             if (tabsOrderRef != null)
            {
                tabsOrderRef.NextTab(); // Llamar al método de TabsOrder
            }
            else
            {
                Console.WriteLine("No se pudo obtener la referencia de TabsOrder");
            }
        }


    }
}