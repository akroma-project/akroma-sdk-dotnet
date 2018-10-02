using Newtonsoft.Json;

namespace Akroma.Model
{
    public class Response<T>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "jsonrpc")]
        public string Jsonrpc = "2.0";
        
        [JsonProperty(PropertyName = "result")]
        public T Result { get; set; }

        public ResponseError Error { get; set; }

        public bool Ok => Error == null;

        public static Response<T> OfError(int code, string message)
        {
            return new Response<T>()
            {
                Error = new ResponseError()
                {
                    Code = code,
                    Message = message
                }
            };
        }

        public static Response<T> OfError(ResponseError error)
        {
            return new Response<T>()
            {
                Error = new ResponseError()
                {
                    Code = error.Code,
                    Message = error.Message
                }
            };
        }
    }
}
