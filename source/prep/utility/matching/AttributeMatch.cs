namespace prep.utility.matching
{
  public class AttributeMatch<ItemToMatch, AttributeType> : IMatchA<ItemToMatch>
  {
    IGetAnAttribute<ItemToMatch, AttributeType> accessor;
    IMatchA<AttributeType> value_matcher;

    public AttributeMatch(IGetAnAttribute<ItemToMatch, AttributeType> accessor, IMatchA<AttributeType> value_matcher)
    {
      this.accessor = accessor;
      this.value_matcher = value_matcher;
    }

    public bool matches(ItemToMatch item)
    {
      var attribute_value = accessor(item);
      return value_matcher.matches(attribute_value);
    }
  }
}