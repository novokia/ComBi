using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComBi
{
  /// <summary>
  /// Base <see cref="Attribute"/> for identifying a proprty to be included in the bindary converstion.
  /// </summary>
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
  public abstract class DataValueAttribute : Attribute, IDataValue
  {
    /// <summary>
    /// 
    /// </summary>
    public uint OrderNumber
    {
      get;
      private set;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderNumber">Provides the order number used during the converstion process.</param>
    protected DataValueAttribute(uint orderNumber)
    {
      OrderNumber = orderNumber;
    }

    public abstract IEnumerable<byte> GetBytes(object value);
  }
}
