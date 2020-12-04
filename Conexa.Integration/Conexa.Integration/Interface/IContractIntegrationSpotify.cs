using Conexa.Integration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexa.Integration.Interface
{
    public interface IContractIntegrationSpotify
    {
        Task<List<Music>> GetPlayList(string genero, string regiao);
    }
}
