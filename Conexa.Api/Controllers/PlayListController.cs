using Conexa.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Conexa.Domain.Contracts.Service;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Conexa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : ControllerBase
    {       
        private readonly IPlaylistService _playlistService;

        public PlaylistController( IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }


        [HttpGet]
        public IEnumerable<Music> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Music
            {
                Name = "Belive - Rhianna"
            })
            .ToArray();
        }

        [HttpGet("GetPlaylistCidade/{cityName}")]
        public async Task<IActionResult> GetPlaylistCity(string cityName)
        {           
            return Ok(_playlistService.GetList(cityName).Result);
        }


        [HttpGet("GetPlaylistLocation/{latitude}/{longitude}")]
        public async Task<IActionResult> GetPlaylistLocation(decimal latitude, decimal longitude)
        {           
            return Ok(_playlistService.GetList(latitude, longitude));
        }

    }
}
