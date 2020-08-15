using AdmissionTest.model.entity;
using Microsoft.EntityFrameworkCore;

namespace AdmissionTest.model.context {
    public class SubcategoryContext : DbContext{
        public DbSet<Subcategory> Subcategories { get; set; }
        public SubcategoryContext(DbContextOptions<SubcategoryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity filters
            modelBuilder.Entity<Subcategory>().HasQueryFilter(s => !s.Archived);
        }
    }
}
