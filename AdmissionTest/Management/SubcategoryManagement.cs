using AdmissionTest.Management.IManagement;
using AdmissionTest.model.context;
using AdmissionTest.model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.Management {
    public class SubcategoryManagement : ISubcategoryManagement {
        private readonly SubcategoryContext subcategoryContext;
        public SubcategoryManagement(SubcategoryContext subcategoryContext)
        {
            this.subcategoryContext = subcategoryContext;
        }

        public IEnumerable<Subcategory> GetAll()
        {
            return subcategoryContext.Subcategories.ToList<Subcategory>();
        }

        public void Save(Subcategory subcategory)
        {
            subcategoryContext.Subcategories.Add(subcategory);
            subcategoryContext.SaveChanges();
        }
    }
}
