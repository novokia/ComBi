namespace ComBi
{
  class ConverstionItem
  {
    public uint OrderNumber
    {
      get;
      set;
    }

    public IDataConverter DataConverter
    {
      get;
      set;
    }

    public object Value
    {
      get;
      set;
    }
  }
}