using System;
using System.Collections.Generic;

namespace ComBi.UnitTests.Setup
{
  class SimpleIntConverter : DataConverter<int>
  {
    protected override IEnumerable<byte> ConvertToBytes(int value)
    {
      return BitConverter.GetBytes(value);
    }
  }
}