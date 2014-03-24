namespace prep.utility.matching
{
  public class ConditionalMatch<Item> : IMatchA<Item>
  {
    Condition<Item> condition;

    public ConditionalMatch(Condition<Item> condition)
    {
      this.condition = condition;
    }

    public bool matches(Item item)
    {
      return condition(item);
    }
  }
}