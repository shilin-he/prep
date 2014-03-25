using System.Collections.Generic;

namespace prep.utility.matching
{
    public class CollectionWhereExtensionPoint<TCollectionElement, TAttributeType>
    {
        public IEnumerable<TCollectionElement> Collection { get; private set; }
        public IGetAnAttribute<TCollectionElement, TAttributeType> AttributeAccessor { get; private set; }

        public CollectionWhereExtensionPoint(IEnumerable<TCollectionElement> collection, IGetAnAttribute<TCollectionElement, TAttributeType> attributeAccessor)
        {
            Collection = collection;
            AttributeAccessor = attributeAccessor;
        }
    }
}