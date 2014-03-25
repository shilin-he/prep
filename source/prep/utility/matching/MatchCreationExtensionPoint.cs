namespace prep.utility.matching
{
  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType> : IProvideAccessToCreateResult<IMatchA<ItemToMatch>, AttributeType>
  {
    IGetAnAttribute<ItemToMatch, AttributeType> accessor;

    public IProvideAccessToCreateResult<IMatchA<ItemToMatch>, AttributeType> not
    {
      get
      {
        return new NegatingMatchCreationExtensionPoint(this);
      }
    }

    class NegatingMatchCreationExtensionPoint : IProvideAccessToCreateResult<IMatchA<ItemToMatch>, AttributeType>
    {
        IProvideAccessToCreateResult<IMatchA<ItemToMatch>, AttributeType> original;

        public NegatingMatchCreationExtensionPoint(IProvideAccessToCreateResult<IMatchA<ItemToMatch>, AttributeType> original)
      {
        this.original = original;
      }

      public IMatchA<ItemToMatch> create(IMatchA<AttributeType> criteria)
      {
        return original.create(criteria).not(); 
      }
    }

    public MatchCreationExtensionPoint(IGetAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> create(IMatchA<AttributeType> criteria)
    {
      return new AttributeMatch<ItemToMatch, AttributeType>(
        accessor ,
        criteria);
    }
  }
}