using AdmissionTest.management.iManagement;
using AdmissionTest.model.entity;
using AdmissionTest.model.exception;
using AdmissionTest.service.iService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace AdmissionTest.service {
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
            if (categoryManagement.FindByName(category.Name) is null)
            {
                try
                {
                    categoryManagement.Save(category);
                }
                catch (Exception ex)
                {
                    throw new CategoryApiException("Can't save the category!", ex);
                }
            }
            else
            {
                throw new CategoryApiException("Category is already exist!");
            }
        }

        public void Update(Category category)
        {
            var updatableCategory = categoryManagement.FindById(category.ID);
            if (updatableCategory is null)
            {
                throw new CategoryApiException("Can't find the category!");
            }
            if (updatableCategory.Name.ToLower().Equals(category.Name.ToLower()))
            {
            
                throw new CategoryApiException("The category's name must be different!");
            }
            try
            {
                throw new CategoryApiException("Not implemented!");
            }
            catch (Exception ex)
            {
                throw new CategoryApiException("Can't save the category!", ex);
            }
        }
    }
}
