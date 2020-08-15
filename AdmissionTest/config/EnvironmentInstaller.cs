using System;
using Microsoft.Extensions.Configuration;

namespace AdmissionTest.config {
    public static class EnvironmentInstaller {
        /// <summary>
        /// Add variable from appsettings to EnvironmentVariables
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            var migrationLocation = configuration.GetValue<string>("DatabaseSettings:MigrationLocation");
            Environment.SetEnvironmentVariable("ConnectionString", connectionString);
            Environment.SetEnvironmentVariable("MigrationLocation", migrationLocation);
        }
    }
}
