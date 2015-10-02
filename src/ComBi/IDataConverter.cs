using System;
using System.Collections.Generic;

namespace ComBi
{
  public interface IDataConverter
  {
    IEnumerable<byte> ConvertToBytes(object value);

    Type ExpectedInputType
    {
      get;
    }
  }
}