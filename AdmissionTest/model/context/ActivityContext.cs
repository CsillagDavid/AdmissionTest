using AdmissionTest.model.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdmissionTest.model.context {
    public class ActivityContext : DbContext {
        public DbSet<Activity> Activities { get; set; }
        public ActivityContext(DbContextOptions<ActivityContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
