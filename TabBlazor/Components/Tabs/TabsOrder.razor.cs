using TabBlazor.Components;

namespace TabBlazor
{
    public partial class TabsOrder : TablerBaseComponent
    {
        private List<ITab> Tabs { get; set; } = new List<ITab>();
        private int CurrentTabIndex { get; set; } = 0;

        public ITab ActiveTab { get; private set; }

        public bool IsLastTab => CurrentTabIndex >= Tabs.Count - 1;

        protected override void OnInitialized()
        {
            // Desactivar todas las pestañas menos la primera
            foreach (var tab in Tabs)
            {
                tab.IsEnabled = false;
            }

            if (Tabs.Any())
            {
                Tabs[0].IsEnabled = true;  // Habilitar la primera pestaña por defecto
                SetActivateTab(Tabs[0]);
            }
        }

        public void AddTab(ITab tab)
        {
            if (!Tabs.Contains(tab))
            {
                tab.IsEnabled = Tabs.Count == 0; // Solo habilita la primera pestaña al agregarla
                Tabs.Add(tab);
            }

            if (ActiveTab == null)
            {
                SetActivateTab(tab);
            }
        }

        public void RemoveTab(ITab tab)
        {
            Tabs.Remove(tab);

            if (ActiveTab == tab)
            {
                SetActivateTab(null);
            }
        }

        public void SetActivateTab(ITab tab)
        {
            if (tab == null || !tab.IsEnabled)
            {
                //ActiveTab = null;

                //StateHasChanged();
                return;
            }

            if (ActiveTab != tab)
            {
                ActiveTab = tab;
                CurrentTabIndex = Tabs.IndexOf(tab);
                StateHasChanged();
            }
        }

        public void NextTab()
        {
            if (CurrentTabIndex < Tabs.Count - 1)
            {
                // Habilitar la siguiente pestaña
                Tabs[CurrentTabIndex + 1].IsEnabled = true;
                CurrentTabIndex++;
                SetActivateTab(Tabs[CurrentTabIndex]);

            }
        }


    }

}
