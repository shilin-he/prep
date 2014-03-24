using prep.collections;

namespace prep.utility.matching
{
  public class MatchFactory<ItemToMatch, AttributeType>
  {
    IGetAnAttribute<ItemToMatch, AttributeType> property_accessor;

    public MatchFactory(IGetAnAttribute<ItemToMatch, AttributeType> property_accessor)
    {
      this.property_accessor = property_accessor;
    }

    public IMatchA<ItemToMatch> equal_to(AttributeType value)
    {
      return new ConditionalMatch<ItemToMatch>(item => 
        property_accessor(item).Equals(value));
    }

    public IMatchA<ItemToMatch> equal_to_any(params AttributeType[] values)
    {
      throw new System.NotImplementedException();
    }
  }
}