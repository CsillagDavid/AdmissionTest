using AdmissionTest.model.entity;
using System.Collections.Generic;

namespace AdmissionTest.management.iManagement {
    public interface ISubcategoryManagement {
        /// <summary>
        /// Save an <see cref="Subcategory"/> entity
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
        /// <summary>
        ///  Return with <see cref="Subcategory"/> entity if it be in the database else return with null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public Subcategory FindById(int id);
    }
}
