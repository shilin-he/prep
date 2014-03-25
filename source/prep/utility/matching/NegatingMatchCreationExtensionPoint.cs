namespace prep.utility.matching
{
  public class NegatingMatchCreationExtensionPoint<ItemToMatch, AttributeType> : ICreateMatchExtensionPoint<ItemToMatch, AttributeType>
  {
    readonly MatchCreationExtensionPoint<ItemToMatch, AttributeType> original;

    public NegatingMatchCreationExtensionPoint(MatchCreationExtensionPoint<ItemToMatch, AttributeType> original)
    {
      this.original = original;
    }

    public IMatchA<ItemToMatch> create_matcher(IMatchA<AttributeType> criteria)
    {
      return original.create_matcher(criteria).not();
    }
  }
}