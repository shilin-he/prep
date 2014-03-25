using System.Collections.Generic;

namespace prep.utility.comparisons
{
  public class AttributeComparer<ItemToCompare, AttributeType> : IComparer<ItemToCompare>
  {
    IGetAnAttribute<ItemToCompare, AttributeType> accessor;
    IComparer<AttributeType> value_comparer;

    public AttributeComparer(IGetAnAttribute<ItemToCompare, AttributeType> accessor, IComparer<AttributeType> value_comparer)
    {
      this.accessor = accessor;
      this.value_comparer = value_comparer;
    }

    public int Compare(ItemToCompare x, ItemToCompare y)
    {
      return value_comparer.Compare(accessor(x), accessor(y));
    }
  }
}