using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ComBi
{
  public static class ComBiSerializer
  {
    public static IEnumerable<byte> Serialize<T>(T value) where T : class
    {
      if(value == null)
      {
        return Enumerable.Empty<byte>();
      }

      var converstionItems = CreateConverstionItems(value);

      return converstionItems.SelectMany(item => item.DataConverter.ConvertToBytes(item.Value));
    }

    static IEnumerable<ConverstionItem> CreateConverstionItems<T>(T value)
    {
      return
        value.GetType()
             .GetProperties()
             .Select(info => new Tuple<PropertyInfo, IConverterAttribute>(info, GetConverterAttribute(info)))
             .Where(tuple => tuple.Item2 != null)
             .OrderBy(tuple => tuple.Item2.OrderNumber)
             .Select(tuple => CreateConverstionItem(tuple.Item1, tuple.Item2, value))
             .Where(item => item != null);
    }

    private static ConverstionItem CreateConverstionItem<T>(PropertyInfo info, IConverterAttribute attribute, T value)
    {
      var converter = Activator.CreateInstance(attribute.ConverterType) as IDataConverter;
      object dataValue;

      if(info.PropertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(info.PropertyType))
      {
        dataValue = info.GetValue(value, null);
        converter = new EnumerableConverter(converter);
      }
      else
      {
        dataValue = info.GetValue(value);
      }

      if(dataValue == null)
      {
        return null;
      }
      
      return new ConverstionItem
             {
               DataConverter = converter,
               OrderNumber = attribute.OrderNumber,
               Value = dataValue,
             };
    }

    private static IConverterAttribute GetConverterAttribute(PropertyInfo info)
    {
      return (IConverterAttribute)info.GetCustomAttribute<DataValueAttribute>() ?? (IConverterAttribute)info.GetCustomAttribute<RecordValueAttribute>();
    }
  }
}
