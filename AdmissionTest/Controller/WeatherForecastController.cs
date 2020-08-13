using System;
using System.Collections.Generic;
using System.Linq;
using AdmissionTest.Management.IManagement;
using AdmissionTest.model.entity;
using AdmissionTest.Service.IService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdmissionTest.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICategoryManagement categoryManagement;
        private readonly ISubcategoryService subcategoryService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICategoryManagement categoryManagement, ISubcategoryService subcategoryService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.categoryManagement = categoryManagement;
            this.subcategoryService = subcategoryService;
        }


        [HttpGet("justsub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<Subcategory> GetAllSub()
        {
            return subcategoryService.GetAll();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IList<Category> GetAll()
        {
            return categoryManagement.GetAll();
        }
    }
}
