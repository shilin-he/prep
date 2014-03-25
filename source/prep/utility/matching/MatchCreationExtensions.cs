using System;
using prep.utility.ranges;

namespace prep.utility.matching
{
  public static class MatchCreationExtensions
  {
    public static IMatchA<ItemToMatch> equal_to<ItemToMatch, AttributeType>(this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType value)
    {
      return equal_to_any(extension_point, value);
    }

    public static IMatchA<ItemToMatch> equal_to_any<ItemToMatch, AttributeType>(this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, params AttributeType[] values)
    {
      return create_conditional_match(extension_point, new EqualToAny<AttributeType>(values));
    }

    public static IMatchA<ItemToMatch> not_equal_to<ItemToMatch, AttributeType>(this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType value)
    {
      return equal_to(extension_point, value).not();
    }

    public static IMatchA<ItemToMatch> create_conditional_match<ItemToMatch, AttributeType>(this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, Condition<ItemToMatch> condition)
    {
      return new ConditionalMatch<ItemToMatch>(condition);
    }

    public static IMatchA<ItemToMatch> create_conditional_match<ItemToMatch, AttributeType>(this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, IMatchA<AttributeType> criteria)
    {
      return new AttributeMatch<ItemToMatch, AttributeType>(extension_point.accesor ,
        criteria);
    }

    public static IMatchA<ItemToMatch> falls_in<ItemToMatch, AttributeType>(this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, IContainValues<AttributeType> range)
      where AttributeType : IComparable<AttributeType>
    {
      return create_conditional_match(extension_point, new FallsInRange<AttributeType>(range));
    }

    public static IMatchA<ItemToMatch> greater_than<ItemToMatch, AttributeType>(this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType value)
where AttributeType : IComparable<AttributeType>
    {
      return falls_in(extension_point, new RangeWithNoUpperBound<AttributeType>(value));
    }


    public static IMatchA<ItemToMatch> between<ItemToMatch, AttributeType>(this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType start, AttributeType end)
where AttributeType : IComparable<AttributeType>
    {
      return falls_in(extension_point, new InclusiveRange<AttributeType>(
        start, end));
    }
  }
}
