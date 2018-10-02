using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Akroma.Model;
using Newtonsoft.Json;

namespace Akroma
{
    public class LegacyWebClient : ILegacyWebClient
    {
        private static readonly HttpClient HttpClient;

        static LegacyWebClient()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        /// <summary>
        /// Calls geth using http
        /// </summary>
        /// <param name="method">https://github.com/ethereum/go-ethereum/wiki/Management-APIs</param>
        /// <param name="items"></param>
        /// <returns></returns>
        //TODO: support non-http providers
        public async Task<Response<T>> PostAsync<T>(string method, params object[] items)
        {
            try
            {

                var content = new Request
                {
                    Method = method,
                    Params = items,
                };

                var contentJson = JsonConvert.SerializeObject(content);
                var response = await HttpClient.PostAsync(Akroma.Url, new StringContent(contentJson, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<Response<T>>(responseString);
                    return responseObject;
                }
                return new Response<T>
                {
                    Error = new ResponseError
                    {
                        Code = (int)response.StatusCode,
                        Message = response.ReasonPhrase,
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<T>
                {
                    Error = new ResponseError
                    {
                        Code = -2022,
                        Message = e.Message
                    }
                };
            }
        }
    }
}
