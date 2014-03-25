using System;

namespace prep.utility.matching
{
  public static class DateTimeMatchCreationExtensions
  {
    public static ReturnType greater_than<ItemToMatch, ReturnType>(
      this IProvideAccessToCreateMatchers<ItemToMatch, DateTime, ReturnType> extension_point, 
      int year)
    {
      var condition = Match<DateTime>.with_attribute(x => x.Year).greater_than(year);
      return extension_point.create_matcher(condition);
    }
  }
}
