using System;
using System.Collections.Generic;
using ComBi.UnitTests.Config;
using FluentAssertions;

namespace ComBi.Converters.UnitTests
{
  public class IntDataConverterTests
  {
    [Input(1234, new byte[] { 0x00, 0x00, 0x04, 0xD2 })]
    [Input(4321, new byte[] { 0x00, 0x00, 0x10, 0xE1 })]
    [Input(-4321, new byte[] { 0xFF, 0xFF, 0xEF, 0x1F })]
    public void ShouldConvertIntBytes(int value, IEnumerable<byte> expectedBytes)
    {
      var converter = new IntDataConverter();
      
      converter.ConvertToBytes(value).ShouldAllBeEquivalentTo(expectedBytes);
    }

    [Input(4321.20)]
    [Input("100")]
    [Input((byte)100)]
    public void ShouldThrowExceptionWrongType<T>(T value)
    {
      var converter = new IntDataConverter();

      var expectedMessage = string.Format("Expected Type of {0}, Actual Type is {1}", typeof(int).Name, typeof(T).Name);

      Action action = () => converter.ConvertToBytes(value);

      action.ShouldThrow<TypeNotSupportedException>().WithMessage(expectedMessage);
    }
  }
}