﻿using AdmissionTest.model.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.model.context {
    public class SubcategoryContext : DbContext{
        public DbSet<Subcategory> Subcategories { get; set; }
        public SubcategoryContext(DbContextOptions<SubcategoryContext> options) : base(options)
        {

        }
    }
}