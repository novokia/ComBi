using System;
using System.Collections.Generic;
using ComBi.UnitTests.Config;
using FluentAssertions;

namespace ComBi.Converters.UnitTests
{
  public class BigEndianIntDataConverterTests
  {
    [Input(1234, new byte[] { 0xD2, 0x04, 0x00, 0x00 })]
    [Input(-4321, new byte[] { 0x1F, 0xEF, 0xFF, 0xFF })]
    public void ShouldConvertIntBytes(int value, IEnumerable<byte> expectedBytes)
    {
      var converter = new BigEndianIntDataConverter();
      
      converter.ConvertToBytes(value).ShouldAllBeEquivalentTo(expectedBytes);
    }

    [Input(4321.20)]
    [Input("100")]
    [Input((byte)100)]
    public void ShouldThrowExceptionWrongType<T>(T value)
    {
      var converter = new BigEndianIntDataConverter();

      var expectedMessage = string.Format("Expected Type of {0}, Actual Type is {1}", typeof(int).Name, typeof(T).Name);

      Action action = () => converter.ConvertToBytes(value);

      action.ShouldThrow<TypeNotSupportedException>().WithMessage(expectedMessage);
    }
  }
}