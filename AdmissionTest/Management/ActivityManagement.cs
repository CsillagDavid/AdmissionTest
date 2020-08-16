using AdmissionTest.management.iManagement;
using AdmissionTest.model.context;
using AdmissionTest.model.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AdmissionTest.management {
    public class ActivityManagement : IActivityManagement {
        private readonly ActivityContext activityContext;
        public ActivityManagement(ActivityContext activityContext)
        {
            this.activityContext = activityContext;
        }

        public void Delete(Activity activity)
        {
            var deletableActivity = activityContext.Activities
                .Include(a => a.Category)
                .Include(a => a.Subcategory).ThenInclude(s => s.Category)
                .First(a => a.ID == activity.ID);
            deletableActivity.Archived = true;
            activityContext.SaveChanges();
        }

        public Activity FindById(int id)
        {
            var activity = activityContext.Activities.Include(a => a.Category).Include(a => a.Subcategory).FirstOrDefault(a => a.ID == id);
            if (activity != null && activity.Subcategory != null)
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
            using (SqlConnection conn = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    conn.Open();

                    SqlTransaction transaction = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.Transaction.Save("Save");

                    try
                    {
                        cmd.CommandText = @"UPDATE activity SET archived = 1 where id=@id";
                        cmd.Parameters.AddWithValue("@id", activity.ID);
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();

                        cmd.CommandText = @"INSERT INTO activity (comment, category, subcategory, start_date, end_date, created_at, modified_at) VALUES
                                        (@comment, @category, @subcategory, @start_date, @end_date, @created_at, @modified_at)";

                        cmd.Parameters.AddWithValue("@comment", activity.Comment);
                        cmd.Parameters.AddWithValue("@category", activity.Category.ID);
                        if (activity.Subcategory != null)
                        {
                            cmd.Parameters.AddWithValue("@subcategory", activity.Subcategory.ID);
                        }
                        else {
                            cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@start_date", activity.StartDate);
                        cmd.Parameters.AddWithValue("@end_date", activity.EndDate);
                        cmd.Parameters.AddWithValue("@created_at", activity.CreatedAt);
                        cmd.Parameters.AddWithValue("@modified_at", activity.ModifiedAt);
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        cmd.Transaction.Rollback("Save");
                        throw;
                        //MessgeBox.Show(e.Message.ToString(), "Error Message");
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Dispose();
                    }
                }
            }
        }
    }
}
