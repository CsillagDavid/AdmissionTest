using AdmissionTest.model.entity;
using System;
using System.Collections.Generic;

namespace AdmissionTest.Management.IManagement {
    public interface IActivityManagement {
        public void Save(Activity activity);
        public IList<Activity> GetByDateTimeInterval(DateTime from, DateTime to);
        public bool IsColliding(Activity activity);
        public bool IsUpdateColliding(Activity activity);
        public IList<Activity> GetAll();
        public void Update(Activity activity);
    }
}
