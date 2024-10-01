using TabBlazor;

namespace IRIS.UI.Services
{
    public class AppSettings
    {
        public bool DarkMode { get; set; }
        public NavbarDirection NavbarDirection { get; set; } = NavbarDirection.Vertical;
        public NavbarBackground NavbarBackground { get; set; } = NavbarBackground.Light;

    }
}
