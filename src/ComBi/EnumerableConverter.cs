using System;
using System.Collections.Generic;
using System.Linq;

namespace ComBi
{
  class EnumerableConverter : IDataConverter
  {
    private readonly IDataConverter _dataConverter;

    public EnumerableConverter(IDataConverter dataConverter)
    {
      _dataConverter = dataConverter;
    }

    public IEnumerable<byte> ConvertToBytes(object value)
    {
      return ((IEnumerable<object>)value).SelectMany(o => _dataConverter.ConvertToBytes(o));
    }

    public Type ExpectedInputType
    {
      get
      {
        return _dataConverter.ExpectedInputType;
      }
    }
  }
}
