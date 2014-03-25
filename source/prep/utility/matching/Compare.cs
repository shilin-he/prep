using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace prep.utility.matching
{
  public static class Compare<ItemToCompare>
  {
    public static Comparer<ItemToCompare> by<AttributeType>(
      IGetAnAttribute<ItemToCompare, AttributeType> attribute_accesor) where AttributeType : IComparable<AttributeType>
    {
      return (x, y) => attribute_accesor(x).CompareTo(attribute_accesor(y));
    }   

    public static Comparer<ItemToCompare> by_descending<AttributeType>(
      IGetAnAttribute<ItemToCompare, AttributeType> attribute_accesor) where AttributeType : IComparable<AttributeType>
    {
      return (x, y) => -by(attribute_accesor)(x, y);
    }   


    public static Comparer<ItemToCompare> by<AttributeType>(
      IGetAnAttribute<ItemToCompare, AttributeType> attribute_accesor, params AttributeType[] values) 
    {
      var temp = new List<AttributeType>(values);
      return (x, y) => temp.IndexOf(attribute_accesor(x)) - temp.IndexOf(attribute_accesor(y));
    }   
  }
}