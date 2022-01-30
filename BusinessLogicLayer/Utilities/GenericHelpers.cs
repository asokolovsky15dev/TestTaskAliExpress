using System;
using System.Collections.Generic;
using System.Linq;

using BusinessLogicLayer.Models;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Utilities
{
    //взято с https://stackoverflow.com/a/19648390
    internal static class GenericHelpers
    {
        public static IEnumerable<CategoryTree> GenerateTree(
            this IEnumerable<Category> collection,
            Func<Category, int?> id_selector,
            Func<Category, int?> parent_id_selector,
            int? root_id = default)
        {
            foreach (var c in collection.Where(c => EqualityComparer<int?>.Default.Equals(parent_id_selector(c), root_id)))
            {
                yield return new CategoryTree
                {
                    Category = c,
                    Children = collection.GenerateTree(id_selector, parent_id_selector, id_selector(c))
                };
            }
        }
    }
}
