namespace Akroma.Core.Model.HexTypes
{
    public interface IHexConvertor<T>
    {
        string ConvertToHex(T value);
        T ConvertFromHex(string value);
    }
}