using System;
using Akroma.Model.HexConvertors.Extensions;
using Akroma.Model.HexTypes;

namespace Akroma.Model.HexConvertors
{
    public class HexUTF8StringConvertor : IHexConvertor<string>
    {
        public string ConvertToHex(String value)
        {
            return value.ToHexUTF8();
        }

        public String ConvertFromHex(string hex)
        {
            return hex.HexToUTF8String();
        }

    }
}
