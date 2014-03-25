using System.Collections.Generic;

namespace prep.utility.matching
{
    public static class CollectionExtensions
    {
        public static CollectionWhereExtensionPoint<TCollectionElement, TAttribute> where
            <TCollectionElement, TAttribute>(this IEnumerable<TCollectionElement> collection,
                IGetAnAttribute<TCollectionElement, TAttribute> attributeAccessor)
        {
            return new CollectionWhereExtensionPoint<TCollectionElement, TAttribute>(collection, attributeAccessor);
        }
    }
}