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

        public IEnumerable<CategoryIncludeSubcategory> GetAllWithSubcategory()
        {
            var categories = categoryContext.CategoriesSubcategorys.Include(c => c.Category).Include(c => c.Subcategory).ToList();
            var result = new List<CategoryIncludeSubcategory>();
            categories.ForEach(c => {
                var category = result.Where(r => r.ID.Equals(c.Category.ID)).FirstOrDefault();
                if (category is null)
                {
                    result.Add(new CategoryIncludeSubcategory()
                    {
                        ID = c.Category.ID,
                        Name = c.Category.Name,
                        CreateAt = c.Category.CreateAt,
                        Subcategories = new List<Subcategory>() { c.Subcategory }
                    });
                }
                else {
                    category.Subcategories.Append(c.Subcategory);
                }
            });
            return result.ToList();
        }

        public void Save(Category category)
        {
            categoryContext.Categories.Add(category);
            categoryContext.SaveChanges();
        }
    }
}
