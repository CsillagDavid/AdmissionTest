using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AdmissionTest.config {
    public static class EnvironmentInstaller {
        public static void Configure(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            var migrationLocation = configuration.GetValue<string>("DatabaseSettings:MigrationLocation");
            Environment.SetEnvironmentVariable("ConnectionString", connectionString);
            Environment.SetEnvironmentVariable("MigrationLocation", migrationLocation);
        }
    }
}
