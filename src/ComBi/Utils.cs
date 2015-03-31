using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComBi
{
  public static class Utils
  {
    public static T GetTypeAs<T>(object value)
    {
      if(value is T)
      {
        return (T)value;
      }

      throw new TypeNotSupportedException(typeof(T), value.GetType());
    }

    public static bool TryGetTypeAs<T>(object value, out T valueAs)
    {
      if(value is T)
      {
        valueAs = (T)value;
        return true;
      }

      valueAs = default(T);
      return false;
    }
  }
}
