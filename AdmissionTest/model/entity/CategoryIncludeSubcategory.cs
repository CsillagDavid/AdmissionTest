using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.model.entity {
    public class CategoryIncludeSubcategory: Category {
        public IEnumerable<Subcategory> Subcategories;
    }
}
