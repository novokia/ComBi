using System;

namespace ComBi.UnitTests.Config
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
  public class InputAttribute : Attribute
  {
    public object[] Parameters
    {
      get;
      private set;
    }

    public InputAttribute(params object[] parameters)
    {
      Parameters = parameters;
    }
  }
}
