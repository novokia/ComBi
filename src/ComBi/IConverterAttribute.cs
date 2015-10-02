using System;

namespace ComBi
{
  public interface IConverterAttribute
  {
    /// <summary>
    /// Order number used for sequencing the bytes in the binary image.
    /// </summary>
    uint OrderNumber
    {
      get;
    }

    /// <summary>
    /// This is a class that implements <see cref="IDataConverter"/>. 
    /// There is no build time checking for this.
    /// </summary>
    Type ConverterType
    {
      get;
      set;
    }

    /// <summary>
    /// The expected type that should match the property type this attribute is being applied to.
    /// </summary>
    Type ExpectedPropertyType
    {
      get;
      set;
    }
  }
}