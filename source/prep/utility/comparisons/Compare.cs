using System;
using System.Collections.Generic;

namespace prep.utility.comparisons
{
  public static class Compare<ItemToCompare>
  {
    public static IComparer<ItemToCompare> by<AttributeType>(
      IGetAnAttribute<ItemToCompare, AttributeType> attribute_accesor, IApplyASortDirection direction) 
      where AttributeType : IComparable<AttributeType>
    {
      IComparer<AttributeType> comparer = new ComparableComparer<AttributeType>();
      return new AttributeComparer<ItemToCompare, AttributeType>(
        attribute_accesor,
        direction.apply_to(comparer));
    }
    public static IComparer<ItemToCompare> by<AttributeType>(
      IGetAnAttribute<ItemToCompare, AttributeType> attribute_accesor) 
      where AttributeType : IComparable<AttributeType>
    {
      return by(attribute_accesor, SortOrders.ascending);
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
    public static IComparer<T> then_by<T,AttributeType>(this IComparer<T> first, IGetAnAttribute<T, 
      AttributeType> accessor) where AttributeType : IComparable<AttributeType>
    {
      return new CombinedComparer<T>(first, Compare<T>.by(accessor)); 
    }
    public static IComparer<T> then_by<T>(this IComparer<T> first, IComparer<T> second)
    {
      return new CombinedComparer<T>(first, second); 
    }
  }
}