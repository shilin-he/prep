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
      return new ConditionalMatch<ItemToMatch>(x =>
        new List<AttributeType>(values).Contains(property_accessor(x)));
    }

    public IMatchA<ItemToMatch> not_equal_to(AttributeType value)
    {
      return equal_to(value).not();
    }
  }
}