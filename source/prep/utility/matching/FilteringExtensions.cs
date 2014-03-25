//using System;
//using System.Collections.Generic;
//
//namespace prep.utility.matching
//{
//    public static class FilteringExtensions
//    {
//        public static IEnumerable<TElementType> greater_than<TElementType>(
//            this FilteringExtensionPoint<TElementType, DateTime> extension_point, int year)
//        {
//            var condition = Match<TElementType>.with_attribute(extension_point.attribute_accessor)
//                    .greater_than(year);
//
//            return extension_point.elements.all_items_matching(condition);
//        }
//    }
//}