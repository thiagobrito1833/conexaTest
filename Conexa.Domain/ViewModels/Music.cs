using Newtonsoft.Json;

namespace Conexa.Domain.ViewModels
{
    public class Musica
    {
        [JsonProperty("name")]
        public string Nome { get; set; }
    }
}
