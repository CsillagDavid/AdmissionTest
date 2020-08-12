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
        private readonly ILogger<ActivityService> logger;

        public ActivityService(ILogger<ActivityService> logger, IActivityManagement activityManagement)
        {
            this.activityManagement = activityManagement;
            this.logger = logger;
        }

        public void Add(Activity activity)
        {
            if (!activityManagement.IsColliding(activity)) {
                activity.CreateAt = DateTime.Now;
                activityManagement.Save(activity);
            }
        }

        public IEnumerable<Activity> GetAll()
        {
            return activityManagement.GetAll();
        }
    }
}
