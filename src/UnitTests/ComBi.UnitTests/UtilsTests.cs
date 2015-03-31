using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComBi.UnitTests.Config;
using FluentAssertions;

namespace ComBi.UnitTests
{
  public class UtilsTests
  {
    [Input("TestValue")]
    [Input(1234)]
    public void ShouldGetTypeAsCorrectly<T>(T value)
    {
      Utils.GetTypeAs<T>(value).Should().Be(value);
    }

    [Input("TestValue", 1234)]
    [Input(1234, "TestValue")]
    public void ShouldThrowExceptionOnTypeMismatchForGetTypeAs<T, U>(T value, U expectedType)
    {
      var expectedMessage = string.Format("Expected Type of {0}, Actual Type is {1}", typeof(U).Name, typeof(T).Name);
      
      Action action = () => Utils.GetTypeAs<U>(value);
      
      action.ShouldThrow<TypeNotSupportedException>().WithMessage(expectedMessage);
    }

    [Input("TestValue")]
    [Input(1234)]
    public void ShouldTryGetTypeAsCorrectly<T>(T value)
    {
      T outValue;
      
      Utils.TryGetTypeAs<T>(value, out outValue).Should().BeTrue();

      outValue.ShouldBeEquivalentTo(value);
    }

    [Input("TestValue", 1234)]
    [Input(1234, "TestValue")]
    [Input(23.25, 1234)]
    public void ShouldReturnFalseOnTypeMismatchForTryGetTypeAs<T, U>(T value, U expectedType)
    {
      U outValue;
      Utils.TryGetTypeAs(value, out outValue).Should().BeFalse();

      outValue.ShouldBeEquivalentTo(default(U));
    }
  }
}
