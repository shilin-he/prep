namespace prep.utility.matching
{
  public class Match<ItemToMatch>
  {
    public static MatchCreationExtensionPoint<ItemToMatch, AttributeType> with_attribute<AttributeType>(
      IGetAnAttribute<ItemToMatch, AttributeType> accesor)
    {
      return new MatchCreationExtensionPoint<ItemToMatch, AttributeType>(accesor);
    }
  }
}