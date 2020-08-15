using System;
using System.Data.SqlClient;

namespace AdmissionTest.config.Database {
    public static class EvolveInstaller {
        /// <summary>
        /// Configure and run migrations
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="migrationLocation"></param>
        public static void Configure(string connectionString, string migrationLocation) {
            try
            {
                var cnx = new SqlConnection(connectionString);
                //var cnx = new SqliteConnection(Configuration.GetConnectionString("MyDatabase"));
                var evolve = new Evolve.Evolve(cnx, msg => Console.WriteLine(msg))
                {
                    Locations = new[] { migrationLocation },
                    IsEraseDisabled = true,
                };

                evolve.Migrate();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                
                throw;
            }
        }
    }
}
