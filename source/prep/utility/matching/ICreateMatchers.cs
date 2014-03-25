namespace prep.utility.matching
{
  public interface ICreateMatchers<ItemToMatch, in AttributeType>
  {
    IMatchA<ItemToMatch> equal_to(AttributeType value);
    IMatchA<ItemToMatch> equal_to_any(params AttributeType[] values);
    IMatchA<ItemToMatch> not_equal_to(AttributeType value);
    IMatchA<ItemToMatch> create_conditional_match(Condition<ItemToMatch> condition);
  }
}