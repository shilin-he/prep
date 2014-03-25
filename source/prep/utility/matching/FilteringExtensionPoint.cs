using System.Collections.Generic;

namespace prep.utility.matching
{
  public class FilteringExtensionPoint<ItemToMatch, AttributeType> :
    IProvideAccessToCreateResult<IEnumerable<ItemToMatch>, AttributeType>
  {
    IEnumerable<ItemToMatch> elements;
    IGetAnAttribute<ItemToMatch, AttributeType> accessor;

    public IProvideAccessToCreateResult<IEnumerable<ItemToMatch>, AttributeType> not
    {
      get { return new NegatingFilteringExtensionPoint(this); }
    }

    class NegatingFilteringExtensionPoint : 
      IProvideAccessToCreateResult<IEnumerable<ItemToMatch>, AttributeType>
    {
      IProvideAccessToCreateResult<IEnumerable<ItemToMatch>, AttributeType> original;

      public NegatingFilteringExtensionPoint(
        IProvideAccessToCreateResult<IEnumerable<ItemToMatch>, AttributeType> original)
      {
        this.original = original;
      }

      public IEnumerable<ItemToMatch> create(IMatchA<AttributeType> criteria)
      {
        return original.create(criteria.not());
      }
    }

    public FilteringExtensionPoint(IEnumerable<ItemToMatch> elements,
      IGetAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      this.elements = elements;
      this.accessor = accessor;
    }

    public IEnumerable<ItemToMatch> create(IMatchA<AttributeType> criteria)
    {
      var condition = Match<ItemToMatch>.with_attribute(accessor)
        .create_conditional_match(criteria);

      return elements.all_items_matching(condition);
    }
  }
}