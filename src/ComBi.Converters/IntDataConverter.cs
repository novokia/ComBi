using System;
using System.Collections.Generic;

namespace ComBi.Converters
{
  public class IntDataConverter : DataConverter<int>
  {
    protected override IEnumerable<byte> ConvertToBytes(int value)
    {
      return BitConverter.GetBytes(value);
    }
  }
}