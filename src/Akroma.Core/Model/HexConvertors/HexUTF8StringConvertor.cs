using System;
using Akroma.Core.Model.HexConvertors.Extensions;
using Akroma.Core.Model.HexTypes;

namespace Akroma.Core.Model.HexConvertors
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
