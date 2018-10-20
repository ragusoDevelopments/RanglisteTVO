using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DaoFactories
    {
        public static IDaoFactory GetFactory(string dataProvider, string ConnectionString)
        {
            switch (dataProvider.ToLower())
            {
                case "sqlite": return new SQLite.DaoFactory(ConnectionString);

                default: return new SQLite.DaoFactory(ConnectionString);
            }
        }
    }
}
