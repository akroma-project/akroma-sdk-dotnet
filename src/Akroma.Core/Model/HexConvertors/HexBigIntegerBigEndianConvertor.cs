using System.Numerics;
using Akroma.Core.Model.HexConvertors.Extensions;
using Akroma.Core.Model.HexTypes;

namespace Akroma.Core.Model.HexConvertors
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
