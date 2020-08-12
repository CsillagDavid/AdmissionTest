using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AdmissionTest.config.Database;
using Microsoft.Extensions.DependencyInjection;

namespace AdmissionTest.config {
    public static class ConfigurationInstaller {
        public static void Configure(IConfiguration configuration, IServiceCollection services) {
            EnvironmentInstaller.Configure(configuration);

            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            var migrationLocation = Environment.GetEnvironmentVariable("MigrationLocation");
            EvolveInstaller.Configure(connectionString, migrationLocation);

            DependencyInstaller.Configure(services, connectionString);
        }
    }
}
