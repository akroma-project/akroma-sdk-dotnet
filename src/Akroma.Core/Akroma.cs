using System.Threading.Tasks;
using Akroma.Core.Model;
using Akroma.Core.Model.HexTypes;

namespace Akroma.Core
{
    public class Akroma
    {
        //TODO: support providers.
        public static string Url;
        private static HttpClientAbstraction _client;

        public Akroma(string url = "http://localhost:8545")
        {
            Url = url;
            _client = new HttpClientAbstraction();
        }


        /// <summary>
        /// </summary>
        /// <param name="address"></param>
        /// <returns>amount in eth/aka</returns>
        public async Task<GethResponse<decimal>> GetBalance(string address)
        {
            var response = await _client.PostAsync<string>("eth_getBalance", address, "latest");
            var balance = UnitConversion.Convert.FromWei(new HexBigInteger(response?.Result));
            return new GethResponse<decimal> {Result = balance};
        }

        /// <summary>
        /// </summary>
        /// <param name="hash">block hash</param>
        /// <returns>Block w/ transaction ids (not full transaction data)</returns>
        public async Task<GethResponse<Block>> GetBlockByHash(string hash)
        {
            return await _client.PostAsync<Block>("eth_getBlockByHash", hash, false);
        }


        /// <summary>
        /// </summary>
        /// <param name="number">integer of a block number, or the string "earliest", "latest" or "pending"</param>
        /// <returns>Block w/ transaction ids (not full transaction data)</returns>
        public async Task<GethResponse<Block>> GetBlockByNumber(string number = "latest")
        {
            return await _client.PostAsync<Block>("eth_getBlockByNumber", number, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="number">integer of a block number, or the string "earliest", "latest" or "pending"</param>
        /// <returns>Block transactions (full transaction data)</returns>
        public async Task<GethResponse<BlockWithTransactions>> GetBlockByNumberWithTransactions(
            string number = "latest")
        {
            object toGet = number;
            if (number != "latest") toGet = $"0x{int.Parse(number):X}";
            return await _client.PostAsync<BlockWithTransactions>("eth_getBlockByNumber", toGet, true);
        }


        public async Task<GethResponse<HexBigInteger>> GetTransactionCountByAddress(string address)
        {
            return await _client.PostAsync<HexBigInteger>("eth_getTransactionCountByAddress", address, 0, "latest",
                "tf", "sc", false);
        }

        public async Task<GethResponse<string[]>> GetTransactionsByAddress(string address)
        {
            return await _client.PostAsync<string[]>("eth_getTransactionsByAddress", address, 0, "latest", "tf", "sc", -1, -1, true);
        }

        public async Task<GethResponse<bool>> Syncing()
        {
            return await _client.PostAsync<bool>("eth_syncing");
        }
    }
}