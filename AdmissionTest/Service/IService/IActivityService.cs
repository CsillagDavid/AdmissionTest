using AdmissionTest.model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.Service.IService {
    public interface IActivityService {
        public void Add(Activity activity);
        public IEnumerable<Activity> GetAll();
        public IEnumerable<Activity> GetByDateTimeInterval(DateTime from, DateTime to);
    }
}
