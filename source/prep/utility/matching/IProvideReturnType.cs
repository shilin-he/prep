namespace prep.utility.matching
{
  public delegate ReturnType IProvideReturnType<out AttributeType, out ReturnType>(IMatchA<AttributeType> attribute_accessor);
}