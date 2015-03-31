using System;

namespace ComBi
{
  /// <summary>
  /// Exception used when 
  /// </summary>
  public class TypeNotSupportedException : Exception
  {
    public TypeNotSupportedException(Type expected, Type actual)
      : base(string.Format("Expected Type of {0}, Actual Type is {1}", expected.Name, actual.Name))
    {
    }
  }
}