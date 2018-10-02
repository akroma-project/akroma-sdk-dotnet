using System.Threading.Tasks;
using Akroma.Model;

namespace Akroma
{
    public interface ILegacyWebClient
    {
        Task<Response<T>> PostAsync<T>(string method, params dynamic[] items);
    }
}
