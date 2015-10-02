using System;
using System.Collections.Generic;
using System.Linq;

namespace ComBi.Converters
{
  public class BigEndianIntDataConverter : DataConverter<int>
  {
    protected override IEnumerable<byte> ConvertToBytes(int value)
    {
      return BitConverter.GetBytes(value).Reverse();
    }
  }
}