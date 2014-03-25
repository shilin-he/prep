namespace prep.utility
{
  public delegate AttributeReturnType IGetAnAttribute<in TypeToRetrieveAttributeFrom, 
  out AttributeReturnType>(TypeToRetrieveAttributeFrom item);





}