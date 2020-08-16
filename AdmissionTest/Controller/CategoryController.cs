using System;
using System.Collections.Generic;
using AdmissionTest.model.entity;
using AdmissionTest.service.iService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdmissionTest.controller {
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService categoryService;
        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.categoryService = categoryService;
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Update(Category category)
        {
            categoryService.Update(category);
        }
    }
}
