using System;

namespace prep.utility.matching
{
  public static class DateTimeMatchCreationExtensions
  {
    public static IMatchA<ItemToMatch> greater_than<ItemToMatch>(
      this MatchCreationExtensionPoint<ItemToMatch, DateTime> extension_point, int year)
    {
      return new ConditionalMatch<ItemToMatch>(item => extension_point.accesor(item).Year > year);
    }
  }
}