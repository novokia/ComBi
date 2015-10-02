using System;
using System.Collections.Generic;
using ComBi.UnitTests.Config;
using FluentAssertions;

namespace ComBi.Converters.UnitTests
{
  public class OptionalAsciiStringDataConverterTests
  {
    [Input("Test", new byte[] { 0x54, 0x65, 0x73, 0x74 })]
    [Input("ASCII", new byte[] { 0x41, 0x53, 0x43, 0x49, 0x49 })]
    [Input("", new byte[0])]
    public void ShouldConvertAsciiStringToBytes(string value, IEnumerable<byte> expectedBytes)
    {
      var converter = new OptionalAsciiStringConverter();
      
      converter.ConvertToBytes(value).ShouldAllBeEquivalentTo(expectedBytes);
    }

    [Input(4321.20)]
    [Input(100u)]
    [Input((byte)100)]
    public void ShouldThrowExceptionWrongType<T>(T value)
    {
      var converter = new ASCIIStringDataConverter();

      var expectedMessage = string.Format("Expected Type of {0}, Actual Type is {1}", typeof(string).Name, typeof(T).Name);

      Action action = () => converter.ConvertToBytes(value);

      action.ShouldThrow<TypeNotSupportedException>().WithMessage(expectedMessage);
    }
  }
}