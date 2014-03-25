using System;
using System.Collections.Generic;

namespace prep.utility.matching
{
    public static class CollectionWhereExtensions
    {
        public static IEnumerable<TElementType> greater_than<TElementType>(
            this CollectionWhereExtensionPoint<TElementType, DateTime> extensionPoint, int year)
        {
            var condition = Match<TElementType>.with_attribute(extensionPoint.AttributeAccessor)
                    .greater_than(year);

            return extensionPoint.Collection.all_items_matching(condition);
        }
    }
}