using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Domain.Entities
{
   public class Music
    {
        public string Name { get; set; }

        public EnumGenre GereMusical { get; set; }
    }

    public enum EnumGenre
    {
        festa = 0,
        pop = 1,
        rock = 2,
        classica = 3
    }

}
