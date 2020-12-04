using Conexa.Domain.Contracts.Service;
using Conexa.Domain.Entities;
using Conexa.Integration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Conexa.Domain.Service
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IContractIntegrationWeathermap _contractIntegrationWeathermap;
        private readonly IContractIntegrationSpotify _integrationSpotify;

        public PlaylistService(IContractIntegrationWeathermap integrationWeathermap, IContractIntegrationSpotify integrationSpotify)
        {
            _contractIntegrationWeathermap = integrationWeathermap;
            _integrationSpotify = integrationSpotify;

        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
        public async Task<ResultAction<Playlist>> GetList(string city)
        {
            var ret = new ResultAction<Playlist>();
            var pl = new Playlist();
            var music = new Music();
            music.Name = "Some Like You";
            pl.Musics.Add(music);
          

            //if (string.IsNullOrEmpty(city))
            //    ret.AddValidation( "Nome da cidade não pode ser vazio!");


            var climate = await _contractIntegrationWeathermap.GetTemperature(city);
            //if (clima == null)
            //    return NotFound("Clima não encontrado para " + city);

            var genre = GetMusicalGenre(climate.getTemperatura());

            var playlist = await _integrationSpotify.GetPlayList(genre.Result.ToString(), climate.Sys.Pais);
            //if (playlist == null)
            //    return NotFound("Playlist não encontrada para cidade " + nomeCidade);

            //Rafactor - AutoMapper
            foreach (var item in playlist)
            {
                 music = new Music();
                music.Name = item.Name;
                pl.Musics.Add(music);
            }    
            return  ret.SetResult(pl);
        }

        public async Task<ResultAction<Playlist>> GetList(decimal longitude, decimal latitude)
        {

            var ret = new ResultAction<Playlist>();
            var pl = new Playlist();
            var music = new Music();
            music.Name = "November rain";
            pl.Musics.Add(music);

            music = new Music();
            music.Name = "Sweet on child";
            pl.Musics.Add(music);

        
            return ret.SetResult(pl);
        }

        public async Task<ResultAction<EnumGenre>> GetMusicalGenre(double temperature)
        {
            var ret = new ResultAction<EnumGenre>();           
          
            var genero = EnumGenre.classica;

            genero = EnumGenre.classica;

            if (temperature > 30)
            {
                genero = EnumGenre.festa;
            }
            else if (temperature >= 15 && temperature <= 30)
            {
                genero = EnumGenre.pop;
            }
            else if (temperature >= 10 && temperature <= 14)
            {
                genero = EnumGenre.rock;
            }

            return ret.SetResult(genero);
        }

        public Task<ResultAction<List<Playlist>>> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
