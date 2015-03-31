using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fixie;

namespace ComBi.UnitTests.Config
{
  public class FromInputAttributes : ParameterSource
  {
    public IEnumerable<object[]> GetParameters(MethodInfo method)
    {
      return method.GetCustomAttributes<InputAttribute>(true).Select(input => input.Parameters);
    }
  }
}