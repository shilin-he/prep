using System;
using System.Collections.Generic;

namespace prep.utility
{
  public static class IEnumerableWhereExtension
  {
    public static DateTimeYearFilter<ItemType> where<ItemType>(this IEnumerable<ItemType> items,
      IGetAnAttribute<ItemType, DateTime> accessor)
    {
      return new DateTimeYearFilter<ItemType>(items, accessor);
    } 
  }
}