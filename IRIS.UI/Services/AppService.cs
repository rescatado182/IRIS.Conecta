using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.UI.Services
{
    public class AppService
    {
        private AppSettings settings = new AppSettings();
        public AppSettings Settings => settings;
        public Action? OnSettingsUpdated;

        public void SettingsUpdated()
        {
            OnSettingsUpdated?.Invoke();
        }
    }
}
