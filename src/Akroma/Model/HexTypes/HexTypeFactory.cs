using System;
using System.Numerics;

namespace Akroma.Model.HexTypes
{
    public class HexTypeFactory
    {
        public static object CreateFromHex<T>(string hex)
        {
            if (typeof(BigInteger) == typeof(T))
            {
                return new HexBigInteger(hex);
            }

            if (typeof(String) == typeof(T))
            {
                return HexString.CreateFromHex(hex);
            }
            throw new NotImplementedException();
        }
    }
}