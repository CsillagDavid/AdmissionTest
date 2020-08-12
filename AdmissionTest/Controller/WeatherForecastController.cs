using System;
using System.Collections.Generic;
using System.Linq;
using AdmissionTest.Management.IManagement;
using AdmissionTest.model.entity;
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
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICategoryManagement categoryManagement)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.categoryManagement = categoryManagement;
        }

        [HttpGet("sub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<CategoryIncludeSubcategory> GetAllCategorySubcategory()
        {
            var retval = categoryManagement.GetAllWithSubcategory();
            return retval;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<Category> GetAll()
        {
            return categoryManagement.GetAll();
        }
    }
}
