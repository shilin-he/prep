namespace prep.utility.matching
{
  public interface IProvideAccessToCreateMatchers<in ItemToMatch, out AttributeType, out ReturnType>
  {
    ReturnType create_matcher(IMatchA<AttributeType> criteria);
  }
}