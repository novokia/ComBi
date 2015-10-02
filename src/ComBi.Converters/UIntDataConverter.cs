using System;
using System.Collections.Generic;

namespace ComBi.Converters
{
  public class UIntDataConverter : DataConverter<uint>
  {
    protected override IEnumerable<byte> ConvertToBytes(uint value)
    {
      return BitConverter.GetBytes(value);
    }
  }
}