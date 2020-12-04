using Conexa.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace Conexa.Domain.ViewModels
{
    public class Track : Entity
    {
        private List<Music> tracks;
  
        public Track()
        {
            tracks = new List<Music>();
        }

        [JsonProperty("tracks")]
        public List<Music> Tracks { get => tracks; set => tracks = value; }
        

    }
}
