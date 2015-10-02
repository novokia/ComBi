using System;
using ComBi.UnitTests.Config;
using FluentAssertions;

namespace ComBi.UnitTests
{
 public class UtilsTests
  {
    [Input("TestValue")]
    [Input(1234)]
    public void ShouldCastCorrectly<T>(T value)
    {
      Utils.Cast<T>(value).Should().Be(value);
    }

    [Input("TestValue", 1234)]
    [Input(1234, "TestValue")]
    [Input(1234.23, 1234)]
    public void ShouldThrowExceptionOnTypeMismatchForGetTypeAs<T, U>(T value, U expectedType)
    {
      var expectedMessage = string.Format("Expected Type of {0}, Actual Type is {1}", typeof(U).Name, typeof(T).Name);
      
      Action action = () => Utils.Cast<U>(value);
      
      action.ShouldThrow<TypeNotSupportedException>().WithMessage(expectedMessage);
    }

    [Input("TestValue")]
    [Input(1234)]
    public void ShouldTryGetTypeAsCorrectly<T>(T value)
    {
      T outValue;
      
      Utils.TryCast(value, out outValue).Should().BeTrue();
      outValue.ShouldBeEquivalentTo(value);
    }

    [Input("TestValue", 1234)]
    [Input(1234, "TestValue")]
    [Input(23.25, 1234)]
    public void ShouldReturnFalseOnTypeMismatchForTryGetTypeAs<T, U>(T value, U expectedType)
    {
      U outValue;

      Utils.TryCast(value, out outValue).Should().BeFalse();

      outValue.ShouldBeEquivalentTo(default(U));
    }
  }
}
