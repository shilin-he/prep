using System;
using System.Security.Policy;

namespace prep.utility.matching
{
  public class ComparableMatchFactory<ItemToMatch, AttributeType> where AttributeType : IComparable<AttributeType>
  {
    IGetAnAttribute<ItemToMatch, AttributeType> accessor;

    public ComparableMatchFactory(IGetAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
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