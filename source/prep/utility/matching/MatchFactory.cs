using System.Collections.Generic;

namespace prep.utility.matching
{
  public class MatchFactory<ItemToMatch, AttributeType> : ICreateMatchers<ItemToMatch, AttributeType>
  {
    IGetAnAttribute<ItemToMatch, AttributeType> property_accessor;

    public MatchFactory(IGetAnAttribute<ItemToMatch, AttributeType> property_accessor)
    {
      this.property_accessor = property_accessor;
    }

    public IMatchA<ItemToMatch> equal_to(AttributeType value)
    {
      return equal_to_any(value);
    }

    public IMatchA<ItemToMatch> equal_to_any(params AttributeType[] values)
    {
      return create_conditional_match(x =>
        new List<AttributeType>(values).Contains(property_accessor(x)));
    }

    public IMatchA<ItemToMatch> not_equal_to(AttributeType value)
    {
      return equal_to(value).not();
    }

    public IMatchA<ItemToMatch> create_conditional_match(Condition<ItemToMatch> condition)
    {
      return new ConditionalMatch<ItemToMatch>(condition);
    }
  }
}