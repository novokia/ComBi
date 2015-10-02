using System.Collections.Generic;
using System.Text;

namespace ComBi.Converters
{
  public class ASCIIStringDataConverter : DataConverter<string>
  {
    protected override IEnumerable<byte> ConvertToBytes(string value)
    {
      return Encoding.ASCII.GetBytes(value);
    }
  }
}