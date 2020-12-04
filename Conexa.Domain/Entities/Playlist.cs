using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Domain.Entities
{
   public class Playlist
    {
        public Playlist()
        {
            Musics = new List<Music>();
        }
        public List<Music> Musics { get; set; }
    }
}
