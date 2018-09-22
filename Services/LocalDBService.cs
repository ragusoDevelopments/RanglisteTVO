using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Services
{
    public class LocalDBService
    {
        private static IDaoFactory factory = DaoFactories.GetFactory("sqlite");
        IParticipantDao participantDao = factory.ParticipantDao;
        ICategoryDao categoryDao = factory.CategoryDao;
        IDisciplineDao disciplineDao = factory.DisciplineDao;
        IStateDao stateDao = factory.StateDao;
        IGenderDao genderDao = factory.GenderDao;


    }
}
