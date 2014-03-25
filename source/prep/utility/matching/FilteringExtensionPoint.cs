using System.Collections.Generic;

namespace prep.utility.matching
{
    public class FilteringExtensionPoint<ItemToMatch, AttributeType> : IProvideAccessToCreateResult<IEnumerable<ItemToMatch>, AttributeType>
    {
        IGetAnAttribute<ItemToMatch, AttributeType> accessor;
        private IEnumerable<ItemToMatch> elements;

        public IProvideAccessToCreateResult<IEnumerable<ItemToMatch>, AttributeType> not
        {
            get
            {
                return new NegatingFilteringExpressionPoint(this);
            }
        }

        class NegatingFilteringExpressionPoint : IProvideAccessToCreateResult<IEnumerable<ItemToMatch>, AttributeType>
        {
            IProvideAccessToCreateResult<IEnumerable<ItemToMatch>, AttributeType> original;

            public NegatingFilteringExpressionPoint(IProvideAccessToCreateResult<IEnumerable<ItemToMatch>, AttributeType> original)
            {
                this.original = original;
            }

            public IEnumerable<ItemToMatch> create(IMatchA<AttributeType> criteria)
            {
                return original.create(criteria.not());
            }
        }

        public FilteringExtensionPoint(IEnumerable<ItemToMatch> elements, IGetAnAttribute<ItemToMatch, AttributeType> accessor)
        {
            this.elements = elements;
            this.accessor = accessor;
        }

        public IEnumerable<ItemToMatch> create(IMatchA<AttributeType> criteria)
        {
            var attributeMatch = new AttributeMatch<ItemToMatch, AttributeType>(
                accessor,
                criteria);

            return elements.all_items_matching(attributeMatch);
        }
    }
}