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

        public void Delete(Activity activity)
        {
            var deletableActivity = activityContext.Activities.Include(a => a.Category).Include(a => a.Subcategory).First(a => a.ID == activity.ID);
            deletableActivity.Archived = true;
            activityContext.Activities.Update(deletableActivity);
            activityContext.SaveChanges();
        }

        public Activity FindById(int id)
        {
            var activity = activityContext.Activities.Include(a => a.Category).Include(a => a.Subcategory).FirstOrDefault(a => a.ID == id);
            if (activity != null)
            {
                activity.Subcategory.Category = null;
            }
            return activity;
        }

        public IList<Activity> GetAll()
        {
            var activities = activityContext.Activities.Include(a => a.Category).Include(a => a.Subcategory).ToList();
            activities.ForEach(a =>
            {
                if (a.Subcategory != null)
                {
                    a.Subcategory.Category = null;
                }
            });
            return activities;
        }

        public IList<Activity> GetByDateTimeInterval(DateTime from, DateTime to)
        {
            var activities = activityContext.Activities.Where(a => ((a.StartDate.CompareTo(to) == -1) && (a.StartDate.CompareTo(from) >= 0)) ||
            (a.EndDate.CompareTo(to) < 1) && (a.EndDate.CompareTo(from) == 1) ||
            (a.StartDate.CompareTo(from) == -1) && (a.EndDate.CompareTo(to) == 1))
            .Include(a => a.Category).Include(a => a.Subcategory).ToList();
            activities.ForEach(a =>
            {
                if (a.Subcategory != null)
                {
                    a.Subcategory.Category = null;
                }
            });
            return activities;
        }

        public bool IsColliding(Activity activity)
        {
            return activityContext.Activities.Any(a => ((activity.StartDate.CompareTo(a.EndDate) == -1) && (activity.StartDate.CompareTo(a.StartDate) >= 0)) ||
            (activity.EndDate.CompareTo(a.EndDate) < 1) && (activity.EndDate.CompareTo(a.StartDate) == 1) ||
            (activity.StartDate.CompareTo(a.StartDate) == -1) && (activity.EndDate.CompareTo(a.EndDate) == 1));
        }

        public bool IsUpdateColliding(Activity activity)
        {
            return activityContext.Activities.Where(a => a.ID != activity.ID).Any(a => ((activity.StartDate.CompareTo(a.EndDate) == -1) && (activity.StartDate.CompareTo(a.StartDate) >= 0)) ||
            (activity.EndDate.CompareTo(a.EndDate) < 1) && (activity.EndDate.CompareTo(a.StartDate) == 1) ||
            (activity.StartDate.CompareTo(a.StartDate) == -1) && (activity.EndDate.CompareTo(a.EndDate) == 1));
        }


        public void Save(Activity activity)
        {
            //activityContext.Activities.FromSql("INSERT INTO ", 
            //    activity.Comment,
            //    activity.Category.ID,
            //    activity.Subcategory.ID,
            //    activity.StartDate,
            //    activity.EndDate
            //    );
            activity.Category.Subcategories = null;
            activityContext.Activities.Add(activity);
            activityContext.Attach(activity.Category);
            if (activity.Subcategory != null)
            {
                activityContext.Attach(activity.Subcategory);
            }
            activityContext.SaveChanges();
        }

        public void Update(Activity activity)
        {
            this.Delete(activity);
            activity.ModifiedAt = DateTime.Now;
            this.Save(activity);
            //updatableActivity.ModifiedAt = DateTime.Now;
            //activityContext.Activities.Update(updatableActivity);
            //if (updatableActivity.Subcategory != null)
            //{
            //    activityContext.Attach(updatableActivity.Subcategory);
            //}
            //activityContext.Attach(updatableActivity.Category);
            //activityContext.SaveChanges();
        }
    }
}
