using AdmissionTest.Management.IManagement;
using AdmissionTest.model.context;
using AdmissionTest.model.entity;
using Microsoft.EntityFrameworkCore;
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
            return categoryContext.Categories.ToList<Category>();
        }

        public IEnumerable<CategorySubcategory> GetAllCategorySubcategory()
        {
            return categoryContext.CategoriesSubcategorys.Include(c => c.Category).Include(c => c.Subcategory).ToList();
        }

        public void Save(Category category)
        {
            categoryContext.Categories.Add(category);
            categoryContext.SaveChanges();
        }
    }
}
