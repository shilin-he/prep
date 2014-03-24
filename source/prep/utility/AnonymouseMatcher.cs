namespace prep.utility
{
  public class AnonymouseMatcher<Item> : IMatchA<Item>
  {
    Condition<Item> condition;

    public AnonymouseMatcher(Condition<Item> condition)
    {
      this.condition = condition;
    }

    public bool matches(Item item)
    {
      return condition(item);
    }
  }
}