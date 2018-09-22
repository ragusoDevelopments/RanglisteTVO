using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQLite
{
    public class DaoFactory : IDaoFactory
    {
        public IParticipantDao ParticipantDao { get { return new ParticipantDao(); } }
        public ICategoryDao CategoryDao { get { return new CategoryDao(); } }
        public IDisciplineDao DisciplineDao { get { return new DisciplineDao(); } }
        public IStateDao StateDao { get { return new StateDao(); } }
        public IGenderDao GenderDao { get { return new GenderDao(); } }
    }
}
