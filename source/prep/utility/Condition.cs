namespace prep.utility
{
  public delegate bool Condition<in ItemToMatch>(ItemToMatch item);
}