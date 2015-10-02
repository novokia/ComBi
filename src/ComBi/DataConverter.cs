using System;
using System.Collections.Generic;
using System.Linq;

namespace ComBi
{
  public abstract class DataConverter<T> : IDataConverter
  {
    public Type ExpectedInputType
    {
      get
      {
        return typeof(T);
      }
    }

    public IEnumerable<byte> ConvertToBytes(object value)
    {
      return value == null ? Enumerable.Empty<byte>() : ConvertToBytes(Utils.Cast<T>(value));
    }

    protected abstract IEnumerable<byte> ConvertToBytes(T value);
  }
}