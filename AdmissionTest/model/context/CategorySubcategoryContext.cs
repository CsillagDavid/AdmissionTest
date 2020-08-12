using AdmissionTest.model.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.model.context {
    public class CategorySubcategoryContext : DbContext {
        public DbSet<CategorySubcategory> CategorySubcategories { get; set; }
        public CategorySubcategoryContext(DbContextOptions<CategorySubcategoryContext> options) : base(options)
        {

        }
    }
}
