using Microsoft.AspNetCore.Components;

namespace TabBlazor
{
    public partial class Alert : TablerBaseComponent
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public bool Dismissible { get; set; }
        [Parameter] public bool Important { get; set; }
        private bool dismissed = false;

        [Parameter]
        public bool ResetDismissed { get; set; }

        protected override void OnParametersSet()
        {
            if (ResetDismissed)
            {
                dismissed = false;
            }
        }
        protected override string ClassNames => ClassBuilder
            .Add("alert")
            .Add(BackgroundColor.GetColorClass("alert"))
            .Add(TextColor.GetColorClass("text"))
            .AddIf("alert-dismissible", Dismissible)
            .AddIf("alert-important", Important)
            .ToString();

        protected void DismissAlert()
        {
            dismissed = true;
        }
    }
}