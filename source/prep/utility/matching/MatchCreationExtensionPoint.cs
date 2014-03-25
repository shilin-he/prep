namespace prep.utility.matching
{
  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType>
  {
    public IGetAnAttribute<ItemToMatch, AttributeType> accesor { get; set; }

    public MatchCreationExtensionPoint(IGetAnAttribute<ItemToMatch, AttributeType> accesor)
    {
      this.accesor = accesor;
    }
  }
}