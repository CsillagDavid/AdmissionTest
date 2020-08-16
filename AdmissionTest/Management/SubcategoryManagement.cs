using AdmissionTest.management.iManagement;
using AdmissionTest.model.context;
using AdmissionTest.model.entity;
using System.Collections.Generic;
using System.Linq;

namespace AdmissionTest.management {
    public class SubcategoryManagement : ISubcategoryManagement {
        private readonly SubcategoryContext subcategoryContext;
        public SubcategoryManagement(SubcategoryContext subcategoryContext)
        {
            this.subcategoryContext = subcategoryContext;
        }

        public void Delete(Subcategory subcategory)
        {
            throw new System.NotImplementedException();
        }

        public Subcategory FindById(int id)
        {
            return subcategoryContext.Subcategories.FirstOrDefault(s => s.ID == id);
        }

        public IEnumerable<Subcategory> GetAll()
        {
            return subcategoryContext.Subcategories.ToList();
        }

        public void Save(Subcategory subcategory)
        {
            subcategoryContext.Subcategories.Add(subcategory);
            subcategoryContext.SaveChanges();
        }

        public void Update(Subcategory subcategory)
        {
            throw new System.NotImplementedException();
        }
    }
}
