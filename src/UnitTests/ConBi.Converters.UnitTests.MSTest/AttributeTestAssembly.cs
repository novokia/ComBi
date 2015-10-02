using ComBi.UnitTests.Config;
using Fixie;

namespace ConBi.Converters.UnitTests.MSTest
{
  public class AttributeTestAssembly : TestAssembly
  {
    public AttributeTestAssembly()
    {
      Apply<InputAttributeConvention>();
    }
  }
}
