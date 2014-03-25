using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using prep.utility.matching;

namespace prep.utility
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
    {
      foreach (var item in items) yield return item;
    }

    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,
      Condition<T> condition)
    {
      foreach (var item in items)
        if(condition(item)) yield return item;
    }
    
    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,
      IMatchA<T> criteria)
    {
      return items.all_items_matching(criteria.matches);
    }

    public static DateTimeYearFilter<ItemType> where<ItemType>(this IEnumerable<ItemType> items,
      IGetAnAttribute<ItemType, DateTime> accessor)
    {
      return new DateTimeYearFilter<ItemType>(items, accessor);
    } 
  }
}