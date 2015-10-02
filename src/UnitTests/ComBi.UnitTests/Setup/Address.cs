namespace ComBi.UnitTests.Setup
{
  class Address
  {
    [DataValue(1, typeof(SimpleStringConverter), typeof(string))]
    public string Street
    {
      get;
      set;
    }

    [DataValue(2, typeof(SimpleStringConverter), typeof(string))]
    public string City
    {
      get;
      set;
    }

    [DataValue(3, typeof(SimpleStringConverter), typeof(string))]
    public string State
    {
      get;
      set;
    }

    [DataValue(4, typeof(SimpleIntConverter), typeof(int))]
    public int ZipCode
    {
      get;
      set;
    }
  }
}