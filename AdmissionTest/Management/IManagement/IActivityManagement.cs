using AdmissionTest.model.entity;
using System;
using System.Collections.Generic;

namespace AdmissionTest.Management.IManagement {
    public interface IActivityManagement {
        /// <summary>
        /// Save <see cref="Activity"/> entity
        /// </summary>
        /// <param name="activity"></param>
        public void Save(Activity activity);
        /// <summary>
        /// Return with a list that contains Activities witch are between a datetime interval
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public IList<Activity> GetByDateTimeInterval(DateTime from, DateTime to);
        /// <summary>
        /// Return true if the <see cref="Activity"/> entity isn't colliding with an other
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public bool IsColliding(Activity activity);
        /// <summary>
        /// Return true if the updateable <see cref="Activity"/> entity isn't colliding with an other
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public bool IsUpdateColliding(Activity activity);
        /// <summary>
        /// Return with all <see cref="Activity"/> entity
        /// </summary>
        /// <returns></returns>
        public IList<Activity> GetAll();
        /// <summary>
        /// Update an <see cref="Activity"/> entity
        /// </summary>
        /// <param name="activity"></param>
        public void Update(Activity activity);
        /// <summary>
        /// Return with <see cref="Activity"/> entity if it be int the database else return with null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Activity FindById(int id);
        /// <summary>
        /// Delete an <see cref="Activity"/> entity
        /// </summary>
        /// <param name="activity"></param>
        public void Delete(Activity activity);
    }
}
