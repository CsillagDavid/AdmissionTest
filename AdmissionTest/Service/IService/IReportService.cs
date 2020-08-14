using AdmissionTest.model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.Service.IService {
    public interface IReportService {
        public Report CreateDailyReport();
    }
}
