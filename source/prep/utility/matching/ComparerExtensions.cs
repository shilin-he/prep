using System;

namespace prep.utility.matching
{
  public static class ComparerExtensions
  {
    public static Comparer<ItemToCompare> then_by<ItemToCompare, AttributeType>(this Comparer<ItemToCompare> first,
      IGetAnAttribute<ItemToCompare, AttributeType> accessor) where AttributeType : IComparable<AttributeType>
    {
      return (x, y) =>
      {
        var result = first(x, y);
        return result == 0 ? accessor(x).CompareTo(accessor(y)) : result;
      };
    }  
  }
}