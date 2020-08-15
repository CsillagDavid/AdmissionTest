using AdmissionTest.model.entity;
using Microsoft.EntityFrameworkCore;

namespace AdmissionTest.model.context {
    public class ActivityContext : DbContext {
        public DbSet<Activity> Activities { get; set; }
        public ActivityContext(DbContextOptions<ActivityContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity filters
            modelBuilder.Entity<Activity>().HasQueryFilter(a => !a.Archived);
        }
    }
}
