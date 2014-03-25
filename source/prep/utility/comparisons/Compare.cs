using System;
using System.Collections.Generic;

namespace prep.utility.comparisons
{
  public static class Compare<ItemToCompare>
  {
    public static IComparer<ItemToCompare> by<AttributeType>(
      IGetAnAttribute<ItemToCompare, AttributeType> attribute_accesor) where AttributeType : IComparable<AttributeType>
    {
      return new AttributeComparer<ItemToCompare, AttributeType>(
        attribute_accesor,
        new ComparableComparer<AttributeType>() );
    }

    public static IComparer<ItemToCompare> by<AttributeType>(
      IGetAnAttribute<ItemToCompare, AttributeType> attribute_accesor, params AttributeType[] values)
    {
      return new AttributeComparer<ItemToCompare, AttributeType>(attribute_accesor,
        new FixedComparer<AttributeType>(values));
    }
  }

  public static class ComparerExtensions
  {
    public static IComparer<T> then_by<T>(this IComparer<T> first, IComparer<T> second)
    {
      return new CombinedComparer<T>(first, second); 
    }
  }
}