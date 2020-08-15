using AdmissionTest.model.entity;
using System.Collections.Generic;

namespace AdmissionTest.Service.IService {
    public interface ISubcategoryService {
        /// <summary>
        /// Save a <see cref="Subcategory"/> entity
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
