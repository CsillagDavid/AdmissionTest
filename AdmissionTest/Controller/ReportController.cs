using System;
using AdmissionTest.model.entity;
using AdmissionTest.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdmissionTest.Controller {
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase {
        private readonly ILogger<ReportController> logger;
        private readonly IReportService reportService;

        public ReportController(ILogger<ReportController> logger, IReportService reportService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(IEnumerable<Category>), StatusCodes.Status200OK)]
        public Report Report()
        {
            return reportService.CreateDailyReport();
        }
    }
}