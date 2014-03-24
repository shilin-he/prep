using prep.collections;

namespace prep.utility.matching
{
  public class Match<ItemToMatch>
  {
    public static MatchFactory<ItemToMatch,AttributeType>
      with_attribute<AttributeType>(IGetAnAttribute<ItemToMatch, AttributeType>
        property_accessor)
    {
      return new MatchFactory<ItemToMatch,AttributeType>(property_accessor);
    }
  }
}