using Conexa.Integration.Interface;
using System;
using System.ComponentModel;

namespace Conexa.Integration
{
    public class AppSettings : ISettingsIntegration
    {

        public AppSettings()
        {

        }
        public const string SettingsIntegrations = "SettingsIntegrations";

        public string KeyWeathermap { get; set; }
        public string TokenSpotify { get; set; }


    }
}
