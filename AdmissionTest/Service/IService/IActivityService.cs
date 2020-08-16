using AdmissionTest.model.entity;
using System;
using System.Collections.Generic;

namespace AdmissionTest.service.iService {
    public interface IActivityService {
        /// <summary>
        /// Add new activity to the database. It can be throw <seealso cref="model.exception.ActivityApiException"/>
        /// </summary>
        /// <param name="activity"></param>
        public void Add(Activity activity);
        /// <summary>
        /// Update an activity. It can be throw <seealso cref="model.exception.ActivityApiException"/>
        /// </summary>
        /// <param name="activity"></param>
        public void Update(Activity activity);
        /// <summary>
        /// Get all Activity entity from database
        /// </summary>
        public IList<Activity> GetAll();
        /// <summary>
        /// Return with a list that contains Activities witch are between a datetime interval
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public IList<Activity> GetByDateTimeInterval(DateTime from, DateTime to);
        /// <summary>
        /// Delete an <see cref="Activity"/> entity
        /// </summary>
        /// <param name="activity"></param>
        public void Delete(Activity activity);
    }
}
