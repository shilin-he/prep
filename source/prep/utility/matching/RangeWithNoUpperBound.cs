using System;
using prep.utility.ranges;

namespace prep.utility.matching
{
  public class RangeWithNoUpperBound<T> : IContainValues<T> where T : IComparable<T>
  {
    T start;

    public RangeWithNoUpperBound(T start)
    {
      this.start = start;
    }

    public bool contains(T item)
    {
      return item.CompareTo(start) > 0;
    }
  }
}