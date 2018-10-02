using Newtonsoft.Json;

namespace Akroma.Model
{
    public class Request
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "jsonrpc")]
        public string Jsonrpc { get; set; } = "2.0";

        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "params")]
        public dynamic[] Params { get; set; }
    }
}
