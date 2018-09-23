using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DaoFactories
    {
        public static IDaoFactory GetFactory(string dataProvider)
        {
            switch (dataProvider.ToLower())
            {
                case "sqlite": return new SQLite.DaoFactory();

                default: return new SQLite.DaoFactory();
            }
        }
    }
}
