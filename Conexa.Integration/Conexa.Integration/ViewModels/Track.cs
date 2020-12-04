
using Newtonsoft.Json;
using System.Collections.Generic;


namespace Conexa.Integration.ViewModels
{
    public class Track 
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
