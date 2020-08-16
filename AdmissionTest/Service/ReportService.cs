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
            //The ReportService use the ActivityService because we don't need to create an ReportService.
            //The ReportService contains whole functionality what the ActivityService contains too so we could simplify the model by placing the ReportService above the ActivityService.
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
                //If it is null that means it contains a new category so need to create a new ReportProperty
                if (categorisedActivity is null)
                {
                    report.CategorisedActivities.Add(new ReportProperty()
                    {
                        SummedTime = a.EndDate.Subtract(a.StartDate).TotalHours,
                        Category = a.Category,
                        Activities = new List<Activity>() { a }
                    });
                }
                //If it isn't null then we summing the activity's duration and add it to the rigth ReportProperty's list
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
