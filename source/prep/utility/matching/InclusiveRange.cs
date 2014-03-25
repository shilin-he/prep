using System;
using prep.utility.ranges;

namespace prep.utility.matching
{
  public class InclusiveRange<T> : IContainValues<T> where T : IComparable<T>
  {
    T start;
    T end;

    public InclusiveRange(T start, T end)
    {
      this.start = start;
      this.end = end;
    }

    public bool contains(T item)
    {
      return item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0;
    }
  }
}