using AdmissionTest.management.iManagement;
using AdmissionTest.model.entity;
using AdmissionTest.model.exception;
using AdmissionTest.service.iService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace AdmissionTest.service {
    public class SubcategoryService : ISubcategoryService {
        private readonly ILogger<SubcategoryService> logger;
        private readonly ISubcategoryManagement subcategoryManagement;

        public SubcategoryService(ISubcategoryManagement subcategoryManagement, ILogger<SubcategoryService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.subcategoryManagement = subcategoryManagement ?? throw new ArgumentNullException(nameof(subcategoryManagement));
        }

        public void Delete(Subcategory subcategory)
        {
            var deletableSubcategory = subcategoryManagement.FindById(subcategory.ID);
            if (deletableSubcategory is null)
            {
                throw new SubcategoryException("Can't find the subcategory!");
            }
            try
            {
                subcategoryManagement.Delete(deletableSubcategory);
            }
            catch (Exception ex)
            {
                throw new SubcategoryException("Can't delete the subcategory!", ex);
            }
            subcategoryManagement.Delete(subcategory);
        }

        public IList<Subcategory> GetAll()
        {
            return subcategoryManagement.GetAll();
        }

        public void Save(Subcategory subcategory)
        {
            subcategoryManagement.Save(subcategory);
        }

        public void Update(Subcategory subcategory)
        {
            throw new NotImplementedException();
        }
    }
}
