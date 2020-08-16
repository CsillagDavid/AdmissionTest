using AdmissionTest.model.entity;
using AdmissionTest.service.iService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdmissionTest.service {
    public class ReportService : IReportService {
        private readonly IActivityService activityService;
        public ReportService(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        public Report CreateDailyReport()
        {
            var today = DateTime.Today;
            var from = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
            var to = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);

            var activities = activityService.GetByDateTimeInterval(from, to).ToList();
            Report report = new Report()
            {
                CategorisedActivities = new List<ReportProperty>()
            };
            activities.ForEach(a =>
            {
                var categorisedActivity = report.CategorisedActivities.FirstOrDefault(c => c.Category.ID == a.Category.ID);
                if (categorisedActivity is null)
                {
                    report.CategorisedActivities.Add(new ReportProperty()
                    {
                        SummedTime = a.EndDate.Subtract(a.StartDate).TotalHours,
                        Category = a.Category,
                        Activities = new List<Activity>() { a }
                    });
                }
                else
                {
                    categorisedActivity.SummedTime += a.EndDate.Subtract(a.StartDate).TotalHours;
                    categorisedActivity.Activities.Add(a);
                }
            });
            return report;
        }
    }
}
