using System.Numerics;
using Akroma.Model.HexConvertors.Extensions;
using Akroma.Model.HexTypes;

namespace Akroma.Model.HexConvertors
{
    public class HexBigIntegerBigEndianConvertor : IHexConvertor<BigInteger>
    {

        public string ConvertToHex(BigInteger newValue)
        {
            return newValue.ToHex(false);
        }

        public BigInteger ConvertFromHex(string hex)
        {
            return hex.HexToBigInteger(false);
        }

    }
}
