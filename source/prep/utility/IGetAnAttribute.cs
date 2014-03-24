namespace prep.utility
{
  public delegate PropertyReturnType IGetAnAttribute<in ItemToInspect, 
  out PropertyReturnType>(ItemToInspect item);
}