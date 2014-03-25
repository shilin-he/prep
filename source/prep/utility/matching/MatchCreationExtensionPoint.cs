namespace prep.utility.matching
{
  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType, ReturnType> : IProvideAccessToCreateMatchers<ItemToMatch, AttributeType, ReturnType>
  {
    IGetAnAttribute<ItemToMatch, AttributeType> accessor;
    IProvideReturnType<AttributeType, ReturnType> return_type_factory;

    public IProvideAccessToCreateMatchers<ItemToMatch, AttributeType, ReturnType> not
    {
      get
      {
        return new NegatingMatchCreationExtensionPoint(this);
      }
    }

    class NegatingMatchCreationExtensionPoint : IProvideAccessToCreateMatchers<ItemToMatch, AttributeType, ReturnType>
    {
      IProvideAccessToCreateMatchers<ItemToMatch, AttributeType, ReturnType> original;

      public NegatingMatchCreationExtensionPoint(IProvideAccessToCreateMatchers<ItemToMatch, AttributeType, ReturnType> original)
      {
        this.original = original;
      }

      public ReturnType create_matcher(IMatchA<AttributeType> criteria)
      {
        return original.create_matcher(criteria.not());
      }
    }

    public MatchCreationExtensionPoint(IGetAnAttribute<ItemToMatch, AttributeType> accessor, IProvideReturnType<AttributeType, ReturnType> return_type_factory)
    {
      this.accessor = accessor;
      this.return_type_factory = return_type_factory;
    }

    public ReturnType create_matcher(IMatchA<AttributeType> criteria)
    {
      return return_type_factory(criteria);
      //      return new AttributeMatch<ItemToMatch, AttributeType>(
      //        accessor ,
      //        criteria);
    }
  }
}
