using System.Collections.Generic;

namespace prep.utility.matching
{
  public class FilteringExtensionPoint<TCollectionElement, TAttributeType>
  {
    public IEnumerable<TCollectionElement> elements { get; private set; }
    public IGetAnAttribute<TCollectionElement, TAttributeType> attribute_accessor { get; private set; }

    public FilteringExtensionPoint(IEnumerable<TCollectionElement> elements,
      IGetAnAttribute<TCollectionElement, TAttributeType> attribute_accessor)
    {
      this.elements = elements;
      this.attribute_accessor = attribute_accessor;
    }
  }
}