﻿using System.Collections.Generic;

namespace ComBi
{
  public interface IDataValue
  {
    /// <summary>
    /// 
    /// </summary>
    uint OrderNumber
    {
      get;
    }

    IEnumerable<byte> GetBytes(object value);
  }
}