using AdmissionTest.model.entity;
using System.Collections.Generic;

namespace AdmissionTest.Service.IService {
    public interface ICategoryService {
        /// <summary>
        /// Save a <see cref="Category"/> entity
        /// </summary>
        /// <returns></returns>
        public void Save(Category category);
        /// <summary>
        /// Return with all <see cref="Category"/> entity
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetAll();
    }
}
