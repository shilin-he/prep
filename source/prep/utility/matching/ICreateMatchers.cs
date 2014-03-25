namespace prep.utility.matching
{
  public interface ICreateMatchers<in ItemToMatch, in AttributeType>
  {
    IMatchA<ItemToMatch> equal_to(AttributeType value);
    IMatchA<ItemToMatch> equal_to_any(params AttributeType[] values);
    IMatchA<ItemToMatch> not_equal_to(AttributeType value);
  }
}