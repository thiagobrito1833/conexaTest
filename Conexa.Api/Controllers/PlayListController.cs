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
    public class PlaylistController : BaseController
    {       
        private readonly IPlaylistService _playlistService;

        public PlaylistController( IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }



        [HttpGet("GetPlaylistCity/{cityName}")]
        public async Task<IActionResult> GetPlaylistCity(string cityName)
        {           
            return ConfigureResult(_playlistService.GetList(cityName));         
        }


        [HttpGet("GetPlaylistLocation/{latitude}/{longitude}")]
        public async Task<IActionResult> GetPlaylistLocation(decimal latitude, decimal longitude)
        {           
            return ConfigureResult(_playlistService.GetList(latitude, longitude));
        }

    }
}
