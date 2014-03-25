﻿using System;
using prep.utility.ranges;

namespace prep.utility.matching
{
  public class FallsInRange<T> : IMatchA<T> where T : IComparable<T>
  {
    IContainValues<T> range;

    public FallsInRange(IContainValues<T> range)
    {
      this.range = range;
    }

    public bool matches(T item)
    {
      return range.contains(item);
    }
  }
}