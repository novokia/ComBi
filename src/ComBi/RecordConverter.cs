using System;
using System.Collections.Generic;

namespace ComBi
{
  public class RecordConverter : IDataConverter
  {
    public IEnumerable<byte> ConvertToBytes(object value)
    {
      return value != null ? ComBiSerializer.Serialize(value) : new byte[0];
    }

    public Type ExpectedInputType
    {
      get
      {
        return typeof(object);
      }
    }
  }
}