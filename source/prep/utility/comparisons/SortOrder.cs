using System.Collections.Generic;

namespace prep.utility.comparisons
{
  public class AscendingSortDirection : IApplyASortDirection
  {
    public IComparer<T> apply_to<T>(IComparer<T> sort)
    {
      return sort;
    }
  }

  public class DoesNotMakeSense : IApplyASortDirection
  {
    public IComparer<T> apply_to<T>(IComparer<T> sort)
    {
      return new ReverseComparer<T>(new ReverseComparer<T>(sort));
    }
  }

  public class DescendingSortDirection : IApplyASortDirection
  {
    public IComparer<T> apply_to<T>(IComparer<T> sort)
    {
      return new ReverseComparer<T>(sort);
    }
  }
  public interface IApplyASortDirection
  {
    IComparer<T> apply_to<T>(IComparer<T> sort); 
  }
  public class SortOrders
  {
    public static readonly IApplyASortDirection descending = new DescendingSortDirection();
    public static readonly IApplyASortDirection ascending = new AscendingSortDirection();
    public static readonly IApplyASortDirection nonsensical = new DoesNotMakeSense();
  }
}