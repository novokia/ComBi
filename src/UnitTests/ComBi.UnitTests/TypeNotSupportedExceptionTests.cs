using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

      exception.Message.Should()
               .Be(string.Format("Expected Type of {0}, Actual Type is {1}", expected.Name, actual.Name));
    }
  }
}
