using AdmissionTest.model.entity;
using System.Collections.Generic;

namespace AdmissionTest.Management.IManagement {
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
        public Category? FindWithName(string name);
    }
}
