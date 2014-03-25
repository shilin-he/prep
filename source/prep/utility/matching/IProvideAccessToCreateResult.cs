namespace prep.utility.matching
{
  public interface IProvideAccessToCreateResult<TResult, out AttributeType>
  {
    TResult create(IMatchA<AttributeType> criteria);
  }
}