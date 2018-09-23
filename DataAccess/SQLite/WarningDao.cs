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
        DBHandler dBHandler = new DBHandler();
        SQLiteConnection conn;

        public WarningDao()
        {
            conn = dBHandler.GetConnection();
        }

        public List<Warning> GetAllWarnings()
        {
            return conn.GetAllWithChildren<Warning>();
        }
    }
}
