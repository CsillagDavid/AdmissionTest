using AdmissionTest.model.entity;
using AdmissionTest.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace AdmissionTest.Controller {
    [ApiController]
    [Route("[controller]")]
    public class ActivityController: ControllerBase {
        private readonly ILogger<ActivityController> logger;
        private readonly IActivityService activityService;

        public ActivityController(ILogger<ActivityController> logger, IActivityService activityService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.activityService = activityService ?? throw new ArgumentNullException(nameof(activityService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(IEnumerable<Category>), StatusCodes.Status200OK)]
        public IList<Activity> GetAll()
        {
            return activityService.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Add(Activity activity)
        {
            try
            {
                activityService.Add(activity);
                logger.LogInformation("Activity saved " + activity);
            }
            catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Update(Activity activity)
        {
            try
            {
                activityService.Update(activity);
                logger.LogInformation("Activity updated " + activity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Delete(Activity activity)
        {
            try
            {
                activityService.Delete(activity);
                logger.LogInformation("Activity deleted " + activity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
