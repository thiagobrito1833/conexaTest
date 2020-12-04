using Newtonsoft.Json;

namespace Conexa.Integration.ViewModels
{
    public class Music
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
