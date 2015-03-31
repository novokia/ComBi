using Fixie;

namespace ComBi.UnitTests.Config
{
  public class InputAttributeConvention : Convention
  {
    public InputAttributeConvention()
    {
      Classes.NameEndsWith("Tests");

      Methods.Where(method => method.IsVoid());

      Parameters.Add<FromInputAttributes>();
    }
  }
}
