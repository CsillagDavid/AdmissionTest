using AdmissionTest.model.entity;
using AdmissionTest.service.iService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.controller {
    [ApiController]
    [Route("[controller]")]
    public class SubcategoryController : ControllerBase {
        private readonly ILogger<SubcategoryController> _logger;
        private readonly ISubcategoryService subcategoryService;
        public SubcategoryController(ILogger<SubcategoryController> logger, ISubcategoryService subcategoryService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.subcategoryService = subcategoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IList<Subcategory> GetAll()
        {
            return subcategoryService.GetAll();
        }

        [HttpPost("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete(Subcategory subcategory)
        {
            subcategoryService.Delete(subcategory);
        }
    }
}
