using AdmissionTest.model.entity;
using System.Collections.Generic;

namespace AdmissionTest.management.iManagement {
    public interface ICategoryManagement {
        /// <summary>
        /// Save an <see cref="Category"/> entity
        /// </summary>
        /// <param name="category"></param>
        public void Save(Category category);
        /// <summary>
        /// Return with all <see cref="Category"/> entity
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetAll();
        /// <summary>
        /// Find an <see cref="Category"/> entity by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Category? FindByName(string name);
        /// <summary>
        /// Find an <see cref="Category"/> by id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Category? FindById(int ID);
        /// <summary>
        /// Update a <see cref="Category"/> entity
        /// </summary>
        /// <param name="category"></param>
        void Update(Category category);
        /// <summary>
        /// Delete a <see cref="Category"/> object
        /// </summary>
        /// <param name="category"></param>
        void Delete(Category category);
    }
}
