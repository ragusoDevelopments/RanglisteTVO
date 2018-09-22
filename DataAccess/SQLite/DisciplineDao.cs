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
    public class DisciplineDao : IDisciplineDao
    {
        DBHandler dbHandler = new DBHandler();
        SQLiteConnection conn;

        public DisciplineDao()
        {
            conn = dbHandler.GetConnection();
        }

        public List<Discipline> GetDisciplines()
        {
            return conn.GetAllWithChildren<Discipline>();
        }

        public void DeleteDiscipline(Discipline discipline)
        {
            conn.Delete(discipline);
        }

        public void InsertDiscipline(Discipline discipline)
        {
            conn.InsertWithChildren(discipline);
        }

        public void UpdateDiscipline(Discipline discipline)
        {
            conn.UpdateWithChildren(discipline);
        }

        private void CleanUpDisciplineValues()
        {
            List<DisciplineValue> dvs = conn.GetAllWithChildren<DisciplineValue>(d => d.DisciplineId.Equals(0));

            conn.DeleteAll(dvs);
        }
    }
}
