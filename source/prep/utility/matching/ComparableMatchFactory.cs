using System;

namespace prep.utility.matching
{
  public class ComparableMatchFactory<ItemToMatch, AttributeType> : ICreateMatchers<ItemToMatch, AttributeType>
    where AttributeType : IComparable<AttributeType>
  {
    IGetAnAttribute<ItemToMatch, AttributeType> accessor;
    ICreateMatchers<ItemToMatch, AttributeType> match_factory;

    public ComparableMatchFactory(IGetAnAttribute<ItemToMatch, AttributeType> accessor, 
      ICreateMatchers<ItemToMatch, AttributeType> match_factory)
    {
      this.accessor = accessor;
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

    public IMatchA<ItemToMatch> greater_than(AttributeType value)
    {
      return new ConditionalMatch<ItemToMatch>(x =>
      {
        var attribute_value = accessor(x);
        return attribute_value.CompareTo(value) > 0;
      });
    }

    public IMatchA<ItemToMatch> between(AttributeType start, AttributeType end)
    {
      return new ConditionalMatch<ItemToMatch>(x =>
      {
        var attribute_value = accessor(x);
        return attribute_value.CompareTo(start) >= 0 && attribute_value.CompareTo(end) <= 0;
      });
    }
  }
}