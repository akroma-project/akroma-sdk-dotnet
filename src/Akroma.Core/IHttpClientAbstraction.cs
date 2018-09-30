using System.Threading.Tasks;
using Akroma.Core.Model;

namespace Akroma.Core
{
    public interface IHttpClientAbstraction
    {
        Task<GethResponse<T>> PostAsync<T>(string method, params dynamic[] items);
    }
}
