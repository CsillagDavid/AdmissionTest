using AdmissionTest.model.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.model.context {
    public class CategoryContext: DbContext {
        public DbSet<Category> Categories { get; set; }
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>()
        //        .HasMany(c => c.Subcategories);
        //}
    }
}
