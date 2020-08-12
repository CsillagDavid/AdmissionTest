using AdmissionTest.model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.Management.IManagement {
    public interface ISubcategoryManagement {
        public void Save(Subcategory subcategory);
        public IEnumerable<Subcategory> GetAll();
    }
}
