using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Extensions;

namespace DataAccess.SQLite
{
    public class WarningDao : IWarningDao
    {
        DBHandler dbHandler;
        SQLiteConnection conn;

        public WarningDao(string dataPath)
        {
            dbHandler = new DBHandler(dataPath);
            conn = dbHandler.GetConnection();
        }

        public List<Warning> GetAllWarnings()
        {
            return conn.GetAllWithChildren<Warning>();
        }
    }
}
