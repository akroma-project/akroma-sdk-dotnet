using System.Threading.Tasks;
using Akroma.Model;
using Akroma.Model.HexTypes;

namespace Akroma
{
    public interface IAkroma
    {
        /// <summary>
        /// </summary>
        /// <param name="address"></param>
        /// <returns>amount in eth/aka</returns>
        Task<Response<decimal>> GetBalance(string address);

        /// <summary>
        /// </summary>
        /// <param name="hash">block hash</param>
        /// <returns>Block w/ transaction ids (not full transaction data)</returns>
        Task<Response<Block>> GetBlockByHash(string hash);

        /// <summary>
        /// </summary>
        /// <param name="number">integer of a block number, or the string "earliest", "latest" or "pending"</param>
        /// <returns>Block w/ transaction ids (not full transaction data)</returns>
        Task<Response<Block>> GetBlockByNumber(string number = "latest");

        /// <summary>
        /// </summary>
        /// <param name="number">integer of a block number, or the string "earliest", "latest" or "pending"</param>
        /// <returns>Block transactions (full transaction data)</returns>
        Task<Response<BlockWithTransactions>> GetBlockByNumberWithTransactions(string number = "latest");

        Task<Response<Transaction>> GetTransactionByHash(string hash);
        Task<Response<HexBigInteger>> GetTransactionCountByAddress(string address);
        Task<Response<string[]>> GetTransactionsByAddress(string address);
        Task<Response<bool>> Listening();
        Task<Response<bool>> Syncing();
    }
}