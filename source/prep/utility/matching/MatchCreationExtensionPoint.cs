namespace prep.utility.matching
{
  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType> : ICreateMatchExtensionPoint<ItemToMatch, AttributeType>
  {
    bool negate;
    IGetAnAttribute<ItemToMatch, AttributeType> accesor;

    public ICreateMatchExtensionPoint<ItemToMatch, AttributeType> not
    {
      get
      {
        return new NegatingMatchCreationExtensionPoint<ItemToMatch, AttributeType>(this);
      }
    }

    public MatchCreationExtensionPoint(IGetAnAttribute<ItemToMatch, AttributeType> accesor)
    {
      this.accesor = accesor;
    }

    public IMatchA<ItemToMatch> create_matcher(IMatchA<AttributeType> criteria)
    {
      var matcher = new AttributeMatch<ItemToMatch, AttributeType>(
        accesor,
        criteria);

      return negate ? matcher.not() : matcher;
    }
  }
}