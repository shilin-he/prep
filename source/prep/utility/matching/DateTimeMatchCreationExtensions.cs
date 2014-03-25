using System;

namespace prep.utility.matching
{
  public static class DateTimeMatchCreationExtensions
  {
      public static TResult greater_than<TResult>(
      this IProvideAccessToCreateResult<TResult, DateTime> extension_point, 
      int year)
    {
      var condition = Match<DateTime>.with_attribute(x => x.Year).greater_than(year);
      return extension_point.create_conditional_match(condition);
    }
  }
}
