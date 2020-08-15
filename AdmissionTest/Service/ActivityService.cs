using AdmissionTest.Management.IManagement;
using AdmissionTest.model.entity;
using AdmissionTest.model.exception;
using AdmissionTest.Service.IService;
using System;
using System.Collections.Generic;

namespace AdmissionTest.Service {
    public class ActivityService : IActivityService {
        private readonly IActivityManagement activityManagement;

        public ActivityService(IActivityManagement activityManagement)
        {
            this.activityManagement = activityManagement;
        }

        public void Add(Activity activity)
        {
            if (activity.EndDate.CompareTo(activity.StartDate) < 1) {
                throw new ActivityApiException("The end date must be greater than start date!");
            }
            if (activity.Comment.Length == 0)
            {
                throw new ActivityApiException("The comment is required!");
            }
            try
            {
                if (!activityManagement.IsColliding(activity))
                {
                    activity.CreateAt = DateTime.Now;
                    activityManagement.Save(activity);
                }
                else
                {
                    throw new ActivityApiException("The activity is colliding with another!");
                }
            }
            catch (ActivityApiException) {
                throw;
            }
            catch (ArgumentNullException ex)
            {
                throw new ActivityApiException("The " + ex.ParamName + " hasn't got value!");
            }
            catch (Exception ex)
            {
                throw new ActivityApiException("Can't save the activity!");
            }
        }

        public void Delete(Activity activity)
        {
            activityManagement.Delete(activity);
        }

        public IList<Activity> GetAll()
        {
            return activityManagement.GetAll();
        }

        public IList<Activity> GetByDateTimeInterval(DateTime from, DateTime to)
        {
            if (to.CompareTo(from) < 1)
            {
                throw new ActivityApiException("The To date must be greater then From date!");
            }
            return activityManagement.GetByDateTimeInterval(from, to);
        }

        public void Update(Activity activity)
        {
            if (activity.EndDate.CompareTo(activity.StartDate) < 1)
            {
                throw new ActivityApiException("The end date must be greater then start date!");
            }
            if (activity.Comment.Length == 0) {
                    throw new ActivityApiException("The comment is required!");
            }
            try
            {
                if (!updatableIsModified(activity)) {
                    throw new ActivityApiException("The activity haven't got modified param!");
                }
                if (!activityManagement.IsUpdateColliding(activity))
                {
                    activity.ModifiedAt = DateTime.Now;
                    activityManagement.Update(activity);
                }
                else
                {
                    throw new ActivityApiException("The activity is colliding with another!");
                }
            }
            catch (ActivityApiException)
            {
                throw;
            }
            catch (ArgumentNullException ex)
            {
                throw new ActivityApiException("The " + ex.ParamName + " hasn't got value!");
            }
            catch (Exception ex)
            {
                throw new ActivityApiException("Can't update the activity!");
            }
        }

        private bool updatableIsModified(Activity activity)
        {
            var oldActivity = activityManagement.FindById(activity.ID);
            if (oldActivity is null) {
                throw new ActivityApiException("The updatable activity not found!");
            }
            return !oldActivity.Comment.Equals(activity.Comment)
                || oldActivity.StartDate.CompareTo(activity.StartDate) != 0
                || oldActivity.EndDate.CompareTo(activity.EndDate) != 0
                || oldActivity.Category.ID != activity.Category.ID
                || (oldActivity.Subcategory is null && activity.Subcategory != null)
                || (activity.Subcategory is null && oldActivity.Subcategory != null)
                || (oldActivity.Subcategory != null && activity.Subcategory != null && oldActivity.Subcategory.ID != activity.Subcategory.ID);
        }
    }
}
