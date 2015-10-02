using System.Collections.Generic;
using System.Text;

namespace ComBi.UnitTests.Setup
{
  class SimpleStringConverter : DataConverter<string>
  {
    protected override IEnumerable<byte> ConvertToBytes(string value)
    {
      return Encoding.ASCII.GetBytes(value);
    }
  }
}