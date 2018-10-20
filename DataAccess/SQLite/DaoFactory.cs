using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQLite
{
    public class DaoFactory : IDaoFactory
    {
        public DaoFactory(string ConnectionString)
        {
            connString = ConnectionString;
        }
        private string connString;

        public IParticipantDao ParticipantDao { get { return new ParticipantDao(connString); } }
        public ICategoryDao CategoryDao { get { return new CategoryDao(connString); } }
        public IDisciplineDao DisciplineDao { get { return new DisciplineDao(connString); } }
        public IStateDao StateDao { get { return new StateDao(connString); } }
        public IGenderDao GenderDao { get { return new GenderDao(connString); } }
        public IDBHandler DBHandler { get { return new DBHandler(connString); } }
        public IWarningDao WarningDao { get { return new WarningDao(connString); } }
    }
}
