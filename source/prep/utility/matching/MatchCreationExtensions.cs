using System;
using prep.utility.ranges;

namespace prep.utility.matching
{
  public static class MatchCreationExtensions
  {
    public static ReturnType equal_to<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToCreateMatchers<ItemToMatch, AttributeType, ReturnType> extension_point, AttributeType value)
    {
      return equal_to_any(extension_point, value);
    }

    public static ReturnType equal_to_any<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToCreateMatchers<ItemToMatch, AttributeType, ReturnType> extension_point, params AttributeType[] values)
    {
      return create_conditional_match(extension_point, new EqualToAny<AttributeType>(values));
    }

    public static ReturnType create_conditional_match<ItemToMatch, AttributeType, ReturnType>(
      this IProvideAccessToCreateMatchers<ItemToMatch, AttributeType, ReturnType> extension_point, IMatchA<AttributeType> criteria)
    {
      return extension_point.create_matcher(criteria);
    }

    public static ReturnType falls_in<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToCreateMatchers<ItemToMatch, AttributeType, ReturnType> extension_point, IContainValues<AttributeType> range)
      where AttributeType : IComparable<AttributeType>
    {
      return create_conditional_match(extension_point, new FallsInRange<AttributeType>(range));
    }

    public static ReturnType greater_than<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToCreateMatchers<ItemToMatch, AttributeType, ReturnType> extension_point, AttributeType value)
where AttributeType : IComparable<AttributeType>
    {
      return falls_in(extension_point, new RangeWithNoUpperBound<AttributeType>(value));
    }


    public static ReturnType between<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToCreateMatchers<ItemToMatch, AttributeType, ReturnType> extension_point, AttributeType start, AttributeType end)
where AttributeType : IComparable<AttributeType>
    {
      return falls_in(extension_point, new InclusiveRange<AttributeType>(
        start, end));
    }
  }
}
