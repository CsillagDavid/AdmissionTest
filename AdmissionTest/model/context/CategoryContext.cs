using AdmissionTest.model.entity;
using Microsoft.EntityFrameworkCore;

namespace AdmissionTest.model.context {
    public class CategoryContext: DbContext {
        public DbSet<Category> Categories { get; set; }
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity filters
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.Archived);
        }
    }
}
