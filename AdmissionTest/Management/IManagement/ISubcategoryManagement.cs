using AdmissionTest.model.entity;
using System.Collections.Generic;

namespace AdmissionTest.Management.IManagement {
    public interface ISubcategoryManagement {
        /// <summary>
        /// Save an <see cref="Subcategory"/> entity
        /// </summary>
        /// <param name="subcategory"></param>
        public void Save(Subcategory subcategory);
        /// <summary>
        /// Return with all <see cref="Subcategory"/> entity
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Subcategory> GetAll();
    }
}
