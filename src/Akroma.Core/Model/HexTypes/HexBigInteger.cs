using System.Numerics;
using Akroma.Core.Model.HexConvertors;
using Newtonsoft.Json;

namespace Akroma.Core.Model.HexTypes
{
    [JsonConverter(typeof(HexRPCTypeJsonConverter<HexBigInteger, BigInteger>))]
    public class HexBigInteger : HexRPCType<BigInteger>
    {


        public HexBigInteger(string hex) : base(new HexBigIntegerBigEndianConvertor(), hex)
        {

        }

        public HexBigInteger(BigInteger value) : base(value, new HexBigIntegerBigEndianConvertor())
        {

        }


    }
}
