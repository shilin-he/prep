namespace prep.utility.matching
{
  public interface ICreateMatchExtensionPoint<in ItemToMatch, out AttributeType>
  {
    IMatchA<ItemToMatch> create_matcher(IMatchA<AttributeType> criteria);
  }
}