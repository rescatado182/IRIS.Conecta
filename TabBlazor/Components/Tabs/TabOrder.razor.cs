using TabBlazor.Components;

namespace TabBlazor
{
    public partial class TabOrder : TablerBaseComponent, ITab
    {
        [CascadingParameter] TabsOrder ContainerTabSet { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment Header { get; set; }

        string TitleCssClass => ContainerTabSet.ActiveTab == this ? "active" : null;

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                StateHasChanged();
            }
        }

        //string TitleCssClass => ContainerTabSet.ActiveTab == this ? "active" : null;
        protected override void OnInitialized()
        {
            if (ContainerTabSet == null)
            {
                throw new InvalidOperationException("Tab component must be used within a Tabs component.");
            }

            ContainerTabSet.AddTab(this);
        }

        public void Dispose()
        {
            ContainerTabSet.RemoveTab(this);
        }

        void Activate()
        {
            // Solo permitir la activación si el tab está habilitado
            if (IsEnabled)
            {
                ContainerTabSet.SetActivateTab(this);
            }
        }
    }
}
