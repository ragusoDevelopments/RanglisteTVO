using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQL
{
    public class DaoFactory : IDaoFactory
    {
        public IDBHandler DBHandler { get { return new DBHandler(); } }
    }
}
