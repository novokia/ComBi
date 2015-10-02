using System;

namespace ComBi
{
  public class RecordValueAttribute : Attribute, IConverterAttribute
  {
    /// <summary>
    /// Order number used for sequencing the bytes in the binary image.
    /// </summary>
    public uint OrderNumber
    {
      get;
      private set;
    }

     /// <summary>
    /// This is a class that implements <see cref="IDataConverter"/>. 
    /// There is no build time checking for this.
    /// </summary>
    public Type ConverterType
    {
      get;
      set;
    }
    
    /// <summary>
    /// The expected type that should match the property type this attribute is being applied to.
    /// </summary>
    public Type ExpectedPropertyType
    {
      get;
      set;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderNumber">Provides the order number used during the converstion process.</param>
    /// <param name="converterType">This is a class that implements <see cref="IDataConverter"/>. 
    /// There is no build time checking for this. </param>
    public RecordValueAttribute(uint orderNumber, Type converterType = null)
    {
      OrderNumber = orderNumber;
      ConverterType = converterType ?? typeof(RecordConverter);
      ExpectedPropertyType = typeof(object);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderNumber">Provides the order number used during the converstion process.</param>
    public RecordValueAttribute(uint orderNumber) : this(orderNumber, typeof(RecordConverter))
    {
    }
  }
}