using System.Threading.Tasks;
using Akroma.Model;
using Akroma.Model.HexTypes;

namespace Akroma
{
    public class Akroma
    {
        //TODO: support providers.
        public static string Url;
        private static LegacyWebClient _client;

        public Akroma(string url = "http://localhost:8545")
        {
            Url = url;
            _client = new LegacyWebClient();
        }

        public async Task<Response<string[]>> FailMethod()
        {
            return await _client.PostAsync<string[]>("undefined_method");
        }


        /// <summary>
        /// </summary>
        /// <param name="address"></param>
        /// <returns>amount in eth/aka</returns>
        public async Task<Response<decimal>> GetBalance(string address)
        {
            var response = await _client.PostAsync<string>("eth_getBalance", address, "latest");
            if (response.Ok)
            {
                var balance = UnitConversion.Convert.FromWei(new HexBigInteger(response?.Result));
                return new Response<decimal> { Result = balance };
            }
            return Response<decimal>.OfError(response.Error);
        }

        /// <summary>
        /// </summary>
        /// <param name="hash">block hash</param>
        /// <returns>Block w/ transaction ids (not full transaction data)</returns>
        public async Task<Response<Block>> GetBlockByHash(string hash)
        {
            return await _client.PostAsync<Block>("eth_getBlockByHash", hash, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="number">integer of a block number, or the string "earliest", "latest" or "pending"</param>
        /// <returns>Block w/ transaction ids (not full transaction data)</returns>
        public async Task<Response<Block>> GetBlockByNumber(string number = "latest")
        {
            return await _client.PostAsync<Block>("eth_getBlockByNumber", number, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="number">integer of a block number, or the string "earliest", "latest" or "pending"</param>
        /// <returns>Block transactions (full transaction data)</returns>
        public async Task<Response<BlockWithTransactions>> GetBlockByNumberWithTransactions(
            string number = "latest")
        {
            object toGet = number;
            if (number != "latest") toGet = $"0x{int.Parse(number):X}";
            return await _client.PostAsync<BlockWithTransactions>("eth_getBlockByNumber", toGet, true);
        }

        public async Task<Response<Transaction>> GetTransactionByHash(string hash)
        {
            return await _client.PostAsync<Transaction>("eth_getTransactionByHash", hash);
        }


        public async Task<Response<HexBigInteger>> GetTransactionCountByAddress(string address)
        {
            return await _client.PostAsync<HexBigInteger>("eth_getTransactionCountByAddress", address, 0, "latest",
                "tf", "sc", false);
        }

        public async Task<Response<string[]>> GetTransactionsByAddress(string address)
        {
            return await _client.PostAsync<string[]>("eth_getTransactionsByAddress", address, 0, "latest", "tf", "sc",
                -1, -1, true);
        }

        public async Task<Response<bool>> Listening()
        {
            return await _client.PostAsync<bool>("net_listening");
        }


        public async Task<Response<bool>> Syncing()
        {
            return await _client.PostAsync<bool>("eth_syncing");
        }
    }
}