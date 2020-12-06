using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using Conexa.Integration.Interface;
using Conexa.Integration.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Conexa.Integration
{
  public  class ContractIntegrationSpotify : IContractIntegrationSpotify
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClient;
      

        private readonly string _remoteServiceBaseUrl;

        public ContractIntegrationSpotify(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;

            _remoteServiceBaseUrl = $"https://api.spotify.com/v1/";
        }



        public async Task<List<Music>> GetPlayList(string genero, string regiao)
        {

            var uri = API.Spotify.GetMusic(_remoteServiceBaseUrl, genero, regiao);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.Value.TokenSpotify);
            var responseString = await _httpClient.GetStringAsync(uri);
            var playlist = JsonConvert.DeserializeObject<Track>(responseString);

            return playlist.Tracks;

        }





    }
}
