using AdmissionTest.Management;
using AdmissionTest.Management.IManagement;
using AdmissionTest.model.context;
using AdmissionTest.Service;
using AdmissionTest.Service.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.config {
    public static class DependencyInstaller {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CategoryContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<SubcategoryContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<ActivityContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<CategorySubcategoryContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<ICategoryManagement, CategoryManagement>();
            services.AddScoped<ISubcategoryManagement, SubcategoryManagement>();
            services.AddScoped<IActivityManagement, ActivityManagement>();

            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();

        }
    }
}
