using Conexa.Integration.Interface;
using System;


public class SettingsIntegration : ISettingsIntegration
{
    public SettingsIntegration()
    {

    }
    public const string SettingsIntegrations = "SettingsIntegrations";

    public string KeyWeathermap { get; set; }
    public string TokenSpotify { get; set; }
}