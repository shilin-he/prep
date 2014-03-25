using System;
using prep.utility.ranges;

namespace prep.utility.matching
{
  public static class MatchCreationExtensions
  {
      public static TResult equal_to<TResult, AttributeType>(this IProvideAccessToCreateResult<TResult, AttributeType> extension_point, AttributeType value)
    {
      return equal_to_any(extension_point, value);
    }

      public static TResult equal_to_any<TResult, AttributeType>(this IProvideAccessToCreateResult<TResult, AttributeType> extension_point, params AttributeType[] values)
    {
      return create_conditional_match(extension_point, new EqualToAny<AttributeType>(values));
    }


    //  public static TResult create_conditional_match<TResult, AttributeType>(this IProvideAccessToCreateResult<TResult, AttributeType> extension_point, Condition<ItemToMatch> condition)
    //{
    //  return new ConditionalMatch<ItemToMatch>(condition);
    //}

      public static TResult create_conditional_match<TResult, AttributeType>(this IProvideAccessToCreateResult<TResult, AttributeType> extension_point, IMatchA<AttributeType> criteria)
    {
      return extension_point.create(criteria);
    }

      public static TResult falls_in<TResult, AttributeType>(this IProvideAccessToCreateResult<TResult, AttributeType> extension_point, IContainValues<AttributeType> range)
      where AttributeType : IComparable<AttributeType>
    {
      return create_conditional_match(extension_point, new FallsInRange<AttributeType>(range));
    }

      public static TResult greater_than<TResult, AttributeType>(this IProvideAccessToCreateResult<TResult, AttributeType> extension_point, AttributeType value)
where AttributeType : IComparable<AttributeType>
    {
      return falls_in(extension_point, new RangeWithNoUpperBound<AttributeType>(value));
    }


      public static TResult between<TResult, AttributeType>(this IProvideAccessToCreateResult<TResult, AttributeType> extension_point, AttributeType start, AttributeType end)
where AttributeType : IComparable<AttributeType>
    {
      return falls_in(extension_point, new InclusiveRange<AttributeType>(
        start, end));
    }
  }
}
