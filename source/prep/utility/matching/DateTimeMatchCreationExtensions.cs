using System;

namespace prep.utility.matching
{
  public static class DateTimeMatchCreationExtensions
  {
    public static IMatchA<ItemToMatch> greater_than<ItemToMatch>(
      this IProvideAccessToCreateMatchers<ItemToMatch, DateTime> extension_point, 
      int year)
    {
      var condition = Match<DateTime>.with_attribute(x => x.Year).greater_than(year);
      return extension_point.create_conditional_match(condition);
    }
  }
}
