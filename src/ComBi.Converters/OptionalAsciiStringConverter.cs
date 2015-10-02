using System.Collections.Generic;
using System.Text;

namespace ComBi.Converters
{
  public class OptionalAsciiStringConverter : DataConverter<string>
  {
    protected override IEnumerable<byte> ConvertToBytes(string value)
    {
      return value == null ? new byte[0] : Encoding.ASCII.GetBytes(value);
    }
  }
}