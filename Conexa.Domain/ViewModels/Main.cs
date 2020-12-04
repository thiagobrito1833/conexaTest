

using Newtonsoft.Json;

namespace Conexa.Domain.ViewModels
{
    public class Main
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }
    }
}
