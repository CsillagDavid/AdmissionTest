using AdmissionTest.management.iManagement;
using AdmissionTest.model.entity;
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
        public IEnumerable<Subcategory> GetAll()
        {
            return subcategoryManagement.GetAll();
        }

        public void Save(Subcategory subcategory)
        {
            subcategoryManagement.Save(subcategory);
        }
    }
}
