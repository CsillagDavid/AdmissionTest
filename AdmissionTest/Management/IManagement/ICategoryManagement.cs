using AdmissionTest.model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.Management.IManagement {
    public interface ICategoryManagement {
        public void Save(Category category);
        public IEnumerable<Category> GetAll();
        public IEnumerable<CategoryIncludeSubcategory> GetAllWithSubcategory();
    }
}
