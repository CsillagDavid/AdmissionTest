using AdmissionTest.Management.IManagement;
using AdmissionTest.model.context;
using AdmissionTest.model.entity;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.Management {
    public class CategoryManagement: ICategoryManagement {
        private readonly CategoryContext categoryContext;
        public CategoryManagement(CategoryContext categoryContext)
        {
            this.categoryContext = categoryContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return categoryContext.Categories.Include(c => c.Subcategories).ToList();
        }

        public void Save(Category category)
        {
            categoryContext.Categories.Add(category);
            categoryContext.SaveChanges();
        }
    }
}
