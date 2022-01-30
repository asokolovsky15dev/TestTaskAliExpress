using DataAccessLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class CategoryTree
    {
        public Category Category { get; set; }

        public IEnumerable<CategoryTree> Children { get; set; }
    }
}

