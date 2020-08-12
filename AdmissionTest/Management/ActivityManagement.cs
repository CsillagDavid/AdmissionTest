using AdmissionTest.Management.IManagement;
using AdmissionTest.model.context;
using AdmissionTest.model.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdmissionTest.Management {
    public class ActivityManagement : IActivityManagement {
        private readonly ActivityContext activityContext;
        public ActivityManagement(ActivityContext activityContext)
        {
            this.activityContext = activityContext;
        }

        public IEnumerable<Activity> GetAll()
        {
            return activityContext.Activities.Include(a => a.Category).Include(a => a.Subcategory).ToList();
        }

        public IEnumerable<Activity> GetByDateTimeInterval(DateTime from, DateTime to)
        {
            return activityContext.Activities.Where(a => ((a.StartDate.CompareTo(to) == -1) && (a.StartDate.CompareTo(from) >= 0)) ||
            (a.EndDate.CompareTo(to) < 1) && (a.EndDate.CompareTo(from) == 1) ||
            (a.StartDate.CompareTo(from) == -1) && (a.EndDate.CompareTo(to) == 1))
            .Include(a => a.Category).Include(a => a.Subcategory)
            .ToList();
        }

        public bool IsColliding(Activity activity)
        {
            // var vmi = activityContext.Activities.Where(a => ((a.StartDate.CompareTo(activity.EndDate) == 1) && (a.EndDate.CompareTo(activity.EndDate) <= 1)) ||
            //(a.StartDate.CompareTo(activity.StartDate) >= 0) && (a.EndDate.CompareTo(activity.StartDate) == -1) ||
            //(a.StartDate.CompareTo(activity.StartDate) == -1) && (a.EndDate.CompareTo(activity.EndDate) == 1));
            // var kkk = activityContext.Activities.Where(a => a.ID > 0).ToList();
            // var asd = kkk.Select(a => ((activity.StartDate.CompareTo(a.EndDate) == -1) && (activity.StartDate.CompareTo(a.StartDate) >= 0)) ||
            // (activity.EndDate.CompareTo(a.EndDate) < 1) && (activity.EndDate.CompareTo(a.StartDate) == 1));
            // var asd2 = kkk.Select(a => ((activity.StartDate.CompareTo(a.EndDate) == -1) && (activity.StartDate.CompareTo(a.StartDate) >= 0)) ||
            // (activity.EndDate.CompareTo(a.EndDate) < 1) && (activity.EndDate.CompareTo(a.StartDate) == 1) ||
            // (activity.StartDate.CompareTo(a.StartDate) == -1) && (activity.EndDate.CompareTo(a.EndDate) == 1));
            return activityContext.Activities.Any(a => ((activity.StartDate.CompareTo(a.EndDate) == -1) && (activity.StartDate.CompareTo(a.StartDate) >= 0)) ||
            (activity.EndDate.CompareTo(a.EndDate) < 1) && (activity.EndDate.CompareTo(a.StartDate) == 1) ||
            (activity.StartDate.CompareTo(a.StartDate) == -1) && (activity.EndDate.CompareTo(a.EndDate) == 1));
        }

        public void Save(Activity activity)
        {
            activityContext.Activities.Add(activity);
            activityContext.Attach(activity.Category);
            //activityContext.Attach(activity.Category.Subcategory);
            activityContext.Attach(activity.Subcategory);
            activityContext.SaveChanges();
        }

        private bool IsColliding(Activity a1, Activity a2)
        {
            return !((a1.StartDate.CompareTo(a2.EndDate) < 1) ||
                (a1.EndDate.CompareTo(a2.StartDate) >= 0));
        }
    }
}
