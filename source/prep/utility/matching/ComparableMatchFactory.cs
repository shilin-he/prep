using System;
using prep.utility.ranges;

namespace prep.utility.matching
{
  public class ComparableMatchFactory<ItemToMatch, AttributeType> : ICreateMatchers<ItemToMatch, AttributeType>
    where AttributeType : IComparable<AttributeType>
  {
    ICreateMatchers<ItemToMatch, AttributeType> match_factory;

    public ComparableMatchFactory(ICreateMatchers<ItemToMatch, AttributeType> match_factory)
    {
      this.match_factory = match_factory;
    }

    public IMatchA<ItemToMatch> equal_to(AttributeType value)
    {
      return match_factory.equal_to(value);
    }

    public IMatchA<ItemToMatch> equal_to_any(params AttributeType[] values)
    {
      return match_factory.equal_to_any(values);
    }

    public IMatchA<ItemToMatch> not_equal_to(AttributeType value)
    {
      return match_factory.not_equal_to(value);
    }

    public IMatchA<ItemToMatch> create_conditional_match(Condition<ItemToMatch> condition)
    {
      return match_factory.create_conditional_match(condition);
    }

    public IMatchA<ItemToMatch> falls_in(IContainValues<AttributeType> range)
    {
      return create_conditional_match(new FallsInRange<AttributeType>(range));
    }

    public IMatchA<ItemToMatch> greater_than(AttributeType value)
    {
      return falls_in(new RangeWithNoUpperBound<AttributeType>(value));
    }

    public IMatchA<ItemToMatch> create_conditional_match(IMatchA<AttributeType> criteria)
    {
      return match_factory.create_conditional_match(criteria);
    }

    public IMatchA<ItemToMatch> between(AttributeType start, AttributeType end)
    {
      return falls_in(new InclusiveRange<AttributeType>(
        start, end));
    }
  }
}