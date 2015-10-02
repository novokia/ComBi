using ComBi.UnitTests.Config;
using Fixie;

namespace ComBi.Converters.UnitTests.Config
{
  public class AttributeTestAssembly : TestAssembly
  {
    public AttributeTestAssembly()
    {
      Apply<InputAttributeConvention>();
    }
  }
}
