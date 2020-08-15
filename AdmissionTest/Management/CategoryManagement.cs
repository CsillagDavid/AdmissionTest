using AdmissionTest.Management.IManagement;
using AdmissionTest.model.context;
using AdmissionTest.model.entity;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace AdmissionTest.Management {
    public class CategoryManagement: ICategoryManagement {
        private readonly CategoryContext categoryContext;
        private readonly SubcategoryContext subcategoryContext;
        public CategoryManagement(CategoryContext categoryContext, SubcategoryContext subcategoryContext)
        {
            this.categoryContext = categoryContext;
            this.subcategoryContext = subcategoryContext;
        }

        public Category FindWithName(string name)
        {
            var lowerName = name.ToLower();
            return categoryContext.Categories.FirstOrDefault(c => c.Name.ToLower().Equals(lowerName));
        }
        
        public IList<Category> GetAll()
        {
            var categories = categoryContext.Categories.ToList();
            categories.ForEach(c => {
                c.Subcategories = subcategoryContext.Subcategories.Include(s => s.Category).Where(s => s.Category.ID.Equals(c.ID)).ToList();
            });
            return categories;
        }

        public void Save(Category category)
        {
            categoryContext.Categories.Add(category);
            categoryContext.SaveChanges();
        }
    }
}
