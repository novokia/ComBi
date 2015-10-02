using System;
using System.Collections.Generic;
using ComBi.UnitTests.Config;
using FluentAssertions;

namespace ComBi.Converters.UnitTests
{
  public class UIntDataConverterTests
  {
    [Input(1234u, new byte[] { 0x00, 0x00, 0x04, 0xD2 })]
    [Input(4321u, new byte[] { 0x00, 0x00, 0x10, 0xE1 })]
    public void ShouldConvertUIntBytes(uint value, IEnumerable<byte> expectedBytes)
    {
      var converter = new UIntDataConverter();
      
      converter.ConvertToBytes(value).ShouldAllBeEquivalentTo(expectedBytes);
    }

    [Input(4321.20)]
    [Input("100")]
    [Input((byte)100)]
    [Input(100)]
    public void ShouldThrowExceptionWrongType<T>(T value)
    {
      var converter = new UIntDataConverter();

      var expectedMessage = string.Format("Expected Type of {0}, Actual Type is {1}", typeof(uint).Name, typeof(T).Name);

      Action action = () => converter.ConvertToBytes(value);

      action.ShouldThrow<TypeNotSupportedException>().WithMessage(expectedMessage);
    }
  }
}