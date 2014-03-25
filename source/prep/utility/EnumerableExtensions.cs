using System;
using System.Collections.Generic;
using prep.utility.matching;

namespace prep.utility
{
  public delegate int Comparer<in ItemToCompare>(ItemToCompare x, ItemToCompare y);

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

    public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items,
      Comparer<T> comparer)
    {
      var sorted = new List<T>(items);
      sorted.Sort(comparer.Invoke);
      return sorted;
    }

    public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items,
      IComparer<T> comparer)
    {
      return items.sort_using(comparer.Compare);
    }

    public static MatchCreationExtensionPoint<ItemToMatch, AttributeType, IEnumerable<ItemToMatch>> where<ItemToMatch, AttributeType>(
      this IEnumerable<ItemToMatch> items, IGetAnAttribute<ItemToMatch, AttributeType> attribute_accessor)
    {
      return new MatchCreationExtensionPoint<ItemToMatch, AttributeType, IEnumerable<ItemToMatch>>(attribute_accessor, 
        spec => items.all_items_matching(new AttributeMatch<ItemToMatch, AttributeType>(attribute_accessor, spec)));
    } 
  }
}