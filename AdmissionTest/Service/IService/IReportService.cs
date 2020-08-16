using AdmissionTest.model.entity;

namespace AdmissionTest.service.iService {
    public interface IReportService {
        /// <summary>
        /// Crreate a <see cref="Report"/> object that contains an <see cref="ReportProperty"/> list that store activities in group by category
        /// </summary>
        public Report CreateDailyReport();
    }
}
