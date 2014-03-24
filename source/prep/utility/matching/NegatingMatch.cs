namespace prep.utility.matching
{
  public class NegatingMatch<Item> : IMatchA<Item>
  {
    IMatchA<Item> original;

    public NegatingMatch(IMatchA<Item> original)
    {
      this.original = original;
    }

    public bool matches(Item item)
    {
      return !original.matches(item);
    }
  }
}