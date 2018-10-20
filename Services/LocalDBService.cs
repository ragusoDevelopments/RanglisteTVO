using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;

namespace Services
{
    public class LocalDBService
    {
        private static IDaoFactory factory = DaoFactories.GetFactory("sqlite", Environment.CurrentDirectory + "\\TestDB.sqlite");
        private static IDBHandler dbhandler = factory.DBHandler;
        private static IParticipantDao participantDao;
        private static ICategoryDao categoryDao;
        private static IDisciplineDao disciplineDao;
        private static IStateDao stateDao;
        private static IGenderDao genderDao;
        private static IWarningDao warningDao;

        /// <summary>
        /// Initializes a new LocalDBService
        /// </summary>
        /// <param name="DBConnectionString">Path to your LocalDB File. Give any path to create a new Database</param>
        public LocalDBService(string DBConnectionString)
        {
            participantDao = factory.ParticipantDao;
            categoryDao = factory.CategoryDao;
            disciplineDao = factory.DisciplineDao;
            stateDao = factory.StateDao;
            genderDao = factory.GenderDao;
            warningDao = factory.WarningDao;
        }
        
        public List<Participant> GetParticipants()
        {
            return participantDao.GetAllParticipants();
        }

        public List<Category> GetCategories()
        {
            return categoryDao.GetAllCategories();
        }

        public List<Discipline> GetDisciplines()
        {
            return disciplineDao.GetDisciplines();
        }

        public List<Warning> GetWarnings()
        {
            return warningDao.GetAllWarnings();
        }
    }
}
