using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Conexa.Integration.ViewModels
{
 public   class Climate
    {
        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("sys")]
        public Sis Sys { get; set; }


        public double getTemperatura()
        {
            return Main.Temp;
        }
    }
}
