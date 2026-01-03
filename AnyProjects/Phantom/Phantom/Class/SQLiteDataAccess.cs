using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Configuration;
using Dapper;

namespace Phantom.Class
{
    public class SQLiteDataAccess
    {

        public static List<PhantomUnit> LoadUnit()
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<PhantomUnit>("select * from Units", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveUnit(PhantomUnit unit)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Execute("insert into Units (Path, Password) values (@Path, @Pathword)", unit);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
