using System.Collections.Generic;

namespace ComBi.UnitTests.Setup
{
  class User
  {
    [DataValue(1, typeof(SimpleIntConverter), typeof(int))]
    public int Id
    {
      get;
      set;
    }

    [DataValue(2, typeof(SimpleStringConverter), typeof(string))]
    public string FullName
    {
      get
      {
        return string.Format("{0} {1}", FirstName, LastName);
      }
    }

    public string FirstName
    {
      get;
      set;
    }

    public string LastName
    {
      get;
      set;
    }

    [DataValue(3, typeof(SimpleStringConverter), typeof(string))]
    public IEnumerable<string> PhoneNumbers
    {
      get;
      set;
    }
    
    [RecordValue(4)]
    public IEnumerable<Address> Addresses
    {
      get;
      set;
    }

    [DataValue(5, typeof(ByteConverter), typeof(byte))]
    public IEnumerable<byte> CalculatedBytes
    {
      get;
      set;
    }

    [DataValue(6, typeof(SimpleStringConverter), typeof(string))]
    public string NickName
    {
      get;
      set;
    }

    [RecordValue(7)]
    public Address ShippingAddresses
    {
      get;
      set;
    }
  }

  public class ByteConverter : DataConverter<byte>
  {
    protected override IEnumerable<byte> ConvertToBytes(byte value)
    {
      return new[] {value};
    }
  }
}