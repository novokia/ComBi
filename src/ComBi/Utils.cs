namespace ComBi
{
  public static class Utils
  {
    public static T Cast<T>(object value)
    {
      if(value is T)
      {
        return (T)value;
      }

      throw new TypeNotSupportedException(typeof(T), value.GetType());
    }
    
    public static bool TryCast<T>(object value, out T valueAs)
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
