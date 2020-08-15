using AdmissionTest.Management;
using AdmissionTest.Management.IManagement;
using AdmissionTest.model.context;
using AdmissionTest.Service;
using AdmissionTest.Service.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdmissionTest.config {
    public static class DependencyInstaller {
        /// <summary>
        /// Make scoped dependencies and creat db contexts
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CategoryContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<SubcategoryContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<ActivityContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<ICategoryManagement, CategoryManagement>();
            services.AddScoped<ISubcategoryManagement, SubcategoryManagement>();
            services.AddScoped<IActivityManagement, ActivityManagement>();

            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();
            services.AddScoped<IReportService, ReportService>();
        }
    }
}
