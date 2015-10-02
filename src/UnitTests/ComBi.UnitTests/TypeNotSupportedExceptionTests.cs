using FluentAssertions;

namespace ComBi.UnitTests
{
  public class TypeNotSupportedExceptionTests
  {
    public void ShouldProperlyFormatExceptionMessage()
    {
      var expected = typeof(int);
      var actual = typeof(string);
      var exception = new TypeNotSupportedException(expected, actual);

      var expectedMessage = string.Format("Expected Type of {0}, Actual Type is {1}", expected.Name, actual.Name);
      exception.Message.Should().Be(expectedMessage);
    }
  }
}
