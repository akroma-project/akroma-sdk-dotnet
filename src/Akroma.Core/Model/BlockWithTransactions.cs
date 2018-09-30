using System.Collections.Generic;
using Newtonsoft.Json;

namespace Akroma.Core.Model
{
    public class BlockWithTransactions : Block
    {
        [JsonProperty(PropertyName = "transactions")]
        public new ICollection<Transaction> Transaction { get; set; } = new List<Transaction>();

    }
}