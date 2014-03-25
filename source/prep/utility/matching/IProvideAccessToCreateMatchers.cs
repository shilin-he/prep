namespace prep.utility.matching
{
  public interface IProvideAccessToCreateMatchers<in ItemToMatch, out AttributeType>
  {
    IMatchA<ItemToMatch> create_matcher(IMatchA<AttributeType> criteria);
  }
}