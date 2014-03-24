namespace prep.utility.matching
{
  public static class MatchExtensions
  {
    public static IMatchA<Item> or<Item>(this IMatchA<Item> left, IMatchA<Item> right)
    {
      return new OrMatch<Item>(left, right);
    }

      public static IMatchA<Item> not<Item>(this IMatchA<Item> left)
      {
          return new NotMatch<Item>(left);
      }
  }
}