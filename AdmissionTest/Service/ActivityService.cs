using AdmissionTest.Management;
using AdmissionTest.Management.IManagement;
using AdmissionTest.model.entity;
using AdmissionTest.Service.IService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.Service {
    public class ActivityService: IActivityService {
        private readonly IActivityManagement activityManagement;

        public ActivityService(IActivityManagement activityManagement)
        {
            this.activityManagement = activityManagement;
        }

        public void Add(Activity activity)
        {
            if (!activityManagement.IsColliding(activity)) {
                activity.CreateAt = DateTime.Now;
                activityManagement.Save(activity);
            }
        }

        public IList<Activity> GetAll()
        {
            return activityManagement.GetAll();
        }

        public IList<Activity> GetByDateTimeInterval(DateTime from, DateTime to)
        {
            return activityManagement.GetByDateTimeInterval(from, to);
        }

        public void Update(Activity activity)
        {
            if (!activityManagement.IsUpdateColliding(activity))
            {
                activity.ModifiedAt = DateTime.Now;
                activityManagement.Update(activity);
            }
        }
    }
}
