using System;
using Microsoft.Extensions.Configuration;
using AdmissionTest.config.Database;
using Microsoft.Extensions.DependencyInjection;

namespace AdmissionTest.config {
    public static class ConfigurationInstaller {
        /// <summary>
        /// Run all configuration class's Configure methode
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="services"></param>
        public static void Configure(IConfiguration configuration, IServiceCollection services) {
            EnvironmentInstaller.Configure(configuration);

            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            var migrationLocation = Environment.GetEnvironmentVariable("MigrationLocation");
            EvolveInstaller.Configure(connectionString, migrationLocation);

            DependencyInstaller.Configure(services, connectionString);
        }
    }
}
