namespace prep.utility.matching
{
  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType> : IProvideAccessToCreateMatchers<ItemToMatch, AttributeType>
  {
    IGetAnAttribute<ItemToMatch, AttributeType> accessor;

    public IProvideAccessToCreateMatchers<ItemToMatch, AttributeType> not
    {
      get
      {
        return new NegatingMatchCreationExtensionPoint(this);
      }
    }

    class NegatingMatchCreationExtensionPoint : IProvideAccessToCreateMatchers<ItemToMatch, AttributeType>
    {
      IProvideAccessToCreateMatchers<ItemToMatch, AttributeType> original;

      public NegatingMatchCreationExtensionPoint(IProvideAccessToCreateMatchers<ItemToMatch, AttributeType> original)
      {
        this.original = original;
      }

      public IMatchA<ItemToMatch> create_matcher(IMatchA<AttributeType> criteria)
      {
        return original.create_matcher(criteria).not(); 
      }
    }

    public MatchCreationExtensionPoint(IGetAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> create_matcher(IMatchA<AttributeType> criteria)
    {
      return new AttributeMatch<ItemToMatch, AttributeType>(
        accessor ,
        criteria);
    }
  }
}