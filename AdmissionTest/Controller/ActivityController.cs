using AdmissionTest.model.entity;
using AdmissionTest.Service;
using AdmissionTest.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.Controller {
    [ApiController]
    [Route("[controller]")]
    public class ActivityController: ControllerBase {
        private readonly ILogger<ActivityController> logger;
        private readonly IActivityService activityService;
        private readonly ICategoryService categoryService;

        public ActivityController(ILogger<ActivityController> logger, IActivityService activityService, ICategoryService categoryService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.activityService = activityService ?? throw new ArgumentNullException(nameof(activityService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(IEnumerable<Category>), StatusCodes.Status200OK)]
        public IEnumerable<Activity> GetAll()
        {
            return activityService.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Activity Add(Activity activity)
        {
            activityService.Add(activity);
            return activity;
        }

        [HttpGet("datetimeinterval")]
        public IEnumerable<Activity> GetByDateTimeInterval(DateTime from, DateTime to) {
            return activityService.GetByDateTimeInterval(from, to);
        }
    }
}
