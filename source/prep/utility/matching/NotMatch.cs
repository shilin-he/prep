namespace prep.utility.matching
{
  public class NotMatch<Item> : IMatchA<Item>
  {
    IMatchA<Item> to_negate;

    public NotMatch(IMatchA<Item> to_negate)
    {
      to_negate = to_negate;
    }

    public bool matches(Item item)
    {
      return !to_negate.matches(item);
    }
  }
}