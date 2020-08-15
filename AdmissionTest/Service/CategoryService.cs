using AdmissionTest.Management.IManagement;
using AdmissionTest.model.entity;
using AdmissionTest.Service.IService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace AdmissionTest.Service {
    public class CategoryService : ICategoryService {
        private readonly ILogger<CategoryService> logger;
        private readonly ICategoryManagement categoryManagement;

        public CategoryService(ICategoryManagement categoryManagement, ILogger<CategoryService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.categoryManagement = categoryManagement ?? throw new ArgumentNullException(nameof(categoryManagement));
        }

        public IList<Category> GetAll()
        {
            return categoryManagement.GetAll();
        }

        public void Save(Category category)
        {
            if (categoryManagement.FindWithName(category.Name) is null) {
                categoryManagement.Save(category);
            }
        }
    }
}
