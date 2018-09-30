using System.Numerics;

namespace Akroma.Core.Model
{
    public static class BigIntegerExtensions
    {
        public static int NumberOfDigits(this BigInteger value)
        {
            return (value * value.Sign).ToString().Length;
        }
    }
}
