using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AdmissionTest.config.Database {
    public static class EvolveInstaller {
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
