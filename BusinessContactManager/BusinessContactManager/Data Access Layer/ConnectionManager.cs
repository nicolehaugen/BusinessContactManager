using BusinessContactManager.Data_Access_Layer;
using BusinessContactManager.DataAccessLayer;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContactManager.Business_Layer
{
    public class ConnectionManager
    {
        private static ConnectionManager connMgr;
        private LocalDatabase database;

        private ConnectionManager(ISqliteConfig sqliteConfig)
        {
            var conn = new SQLiteConnection(sqliteConfig.Path);
            database = new LocalDatabase(conn);
        }

        public static ConnectionManager GetConnection(ISqliteConfig sqliteConfig)
        {
            if (connMgr == null)
            {
                connMgr = new ConnectionManager(sqliteConfig);
            }

            return connMgr;
        }

        internal LocalDatabase Database
        {
            get { return database; }
        }
    }
}
