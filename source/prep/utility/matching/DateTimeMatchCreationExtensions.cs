using System;

namespace prep.utility.matching
{
  public static class DateTimeMatchCreationExtensions
  {
    public static IMatchA<ItemToMatch> greater_than<ItemToMatch>(
      this MatchCreationExtensionPoint<ItemToMatch, DateTime> extension_point, int year)
    {
      return extension_point.create_conditional_match(item => extension_point.accesor(item).Year > year);
    }
  }
}