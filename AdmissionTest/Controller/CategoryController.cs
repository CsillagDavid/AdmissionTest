using System;
using System.Collections.Generic;
using AdmissionTest.Management.IManagement;
using AdmissionTest.model.entity;
using AdmissionTest.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdmissionTest.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService categoryService;
        private readonly ISubcategoryService subcategoryService;
        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService, ISubcategoryService subcategoryService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.categoryService = categoryService;
            this.subcategoryService = subcategoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IList<Category> GetAll()
        {
            return categoryService.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Add(Category category)
        {
            categoryService.Save(category);
        }
    }
}
