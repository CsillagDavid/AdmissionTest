using AdmissionTest.model.entity;
using System.Collections.Generic;

namespace AdmissionTest.service.iService {
    public interface ISubcategoryService {
        /// <summary>
        /// Save a <see cref="Subcategory"/> entity
        /// </summary>
        /// <param name="subcategory"></param>
        public void Save(Subcategory subcategory);
        /// <summary>
        /// Delete a <see cref="Subcategory"/> entity
        /// </summary>
        /// <param name="subcategory"></param>
        public void Delete(Subcategory subcategory);
        /// <summary>
        /// Update a <see cref="Subcategory"/> entity
        /// </summary>
        /// <param name="subcategory"></param>
        public void Update(Subcategory subcategory);
        /// <summary>
        /// Return with all <see cref="Subcategory"/> entity
        /// </summary>
        /// <returns></returns>
        public IList<Subcategory> GetAll();
    }
}
