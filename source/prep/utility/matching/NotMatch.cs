namespace prep.utility.matching
{
    public class NotMatch<Item> : IMatchA<Item>
    {
        private readonly IMatchA<Item> _left;

        public NotMatch(IMatchA<Item> left)
        {
            _left = left;
        }

        public bool matches(Item item)
        {
            return !_left.matches(item);
        }
    }
}