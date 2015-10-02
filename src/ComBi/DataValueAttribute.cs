using System;

namespace ComBi
{
  /// <summary>
  /// <see cref="Attribute"/> for identifying a property to be included in the bindary converstion.
  /// Includes the order and <see cref="IDataConverter"/> to be used to convert the value to bytes/
  /// </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public class DataValueAttribute : Attribute, IConverterAttribute
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

    public object[] ConverterParams
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
    /// <param name="expectedPropertyType">The expected type that should match the property type this 
    /// attribute is being applied to. Default value is null, if left null type checking will not be 
    /// performed by the validator.</param>
    /// <param name="converterParams"></param>
    public DataValueAttribute(uint orderNumber, Type converterType, Type expectedPropertyType, params object[] converterParams)
    {
      OrderNumber = orderNumber;
      ConverterType = converterType;
      ExpectedPropertyType = expectedPropertyType;
      ConverterParams = converterParams;
    }
  }
}
