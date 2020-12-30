
using System.Collections.Generic;

namespace Conexa.Domain.Entities
{
   public class Playlist : ViewBase
    {
        public Playlist()
        {
            Musics = new List<Music>();
        }
        public List<Music> Musics { get; set; }
    }
}
