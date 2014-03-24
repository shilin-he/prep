using System;

namespace prep.utility.matching
{
  public class Match<ItemToMatch>
  {
    public static MatchFactory<ItemToMatch, AttributeType>
      with_attribute<AttributeType>(IGetAnAttribute<ItemToMatch, AttributeType>
        property_accessor)
    {
      return new MatchFactory<ItemToMatch, AttributeType>(property_accessor);
    }

    public static ComparableMatchFactory<ItemToMatch, AttributeType> with_comparable_attribute<AttributeType>(IGetAnAttribute<ItemToMatch, AttributeType>  accesor)
      where AttributeType : IComparable<AttributeType>
    {
      return new ComparableMatchFactory<ItemToMatch, AttributeType>(accesor);
    }
  }
}