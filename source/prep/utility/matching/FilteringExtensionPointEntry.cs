using System.Collections.Generic;

namespace prep.utility.matching
{
  public static class FilteringExtensionPointEntry
  {
    public static FilteringExtensionPoint<TCollectionElement, TAttribute> where
      <TCollectionElement, TAttribute>(this IEnumerable<TCollectionElement> elements,
        IGetAnAttribute<TCollectionElement, TAttribute> attribute_accessor)
    {
      return new FilteringExtensionPoint<TCollectionElement, TAttribute>(elements, attribute_accessor);
    }
  }
}