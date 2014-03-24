namespace prep.utility
{
  public interface IMatchA<in Item>
  {
    bool matches(Item item);
  }
}