using Conexa.Domain.Entities;
using System.Threading.Tasks;

namespace Conexa.Domain.Contracts.Service
{
  public  interface IPlaylistService : IBaseService<Playlist>
    {
        Task<ResultAction<Playlist>> GetList(string city);

        Task<ResultAction<Playlist>> GetList(decimal longitude, decimal latitude);
        Task<ResultAction<EnumGenre>> GetMusicalGenre(double temperature);
    }
}
