namespace prep.utility.matching
{
  public class Match<ItemToMatch>
  {
    public static MatchCreationExtensionPoint<ItemToMatch, AttributeType, IMatchA<ItemToMatch>> with_attribute<AttributeType>(
      IGetAnAttribute<ItemToMatch, AttributeType> accesor)
    {
      return new MatchCreationExtensionPoint<ItemToMatch, AttributeType, IMatchA<ItemToMatch>>(
        accesor, spec => new AttributeMatch<ItemToMatch, AttributeType>(accesor, spec));
    }
  }
}