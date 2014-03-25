using System;
using System.Collections.Generic;
using prep.utility.matching;

namespace prep.utility
{
  public class DateTimeYearFilter<ItemType>
  {
    readonly IEnumerable<ItemType> items;
    readonly IGetAnAttribute<ItemType, DateTime> accessor;

    public DateTimeYearFilter(IEnumerable<ItemType> items, IGetAnAttribute<ItemType, DateTime> accessor)
    {
      this.items = items;
      this.accessor = accessor;
    }

    public IEnumerable<ItemType> greater_than(int value)
    {
      return items.all_items_matching(Match<ItemType>.with_attribute(accessor).greater_than(value));
    } 
  }
}