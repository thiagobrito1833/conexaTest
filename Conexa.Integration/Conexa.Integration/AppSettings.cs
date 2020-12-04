using System;
using System.ComponentModel;

namespace Conexa.Integration
{
    public class AppSettings
    {
       

        [DefaultValue("")]
        public string KeyWeathermap { get; set; }
        [DefaultValue("")]
        public string KeySpotify { get; set; }




    }
}
