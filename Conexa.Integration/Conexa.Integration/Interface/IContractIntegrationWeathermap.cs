using Conexa.Integration.ViewModels;
using System.Threading.Tasks;

namespace Conexa.Integration.Interface
{
   public interface IContractIntegrationWeathermap
    {
        Task<Climate> GetTemperature(string city);
        Task<Climate> GetTemperature(double longitude, double latitude);
    }
}
