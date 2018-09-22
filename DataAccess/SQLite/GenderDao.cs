using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace DataAccess.SQLite
{
    public class GenderDao : IGenderDao
    {
        DBHandler dbhandler = new DBHandler();
        SQLiteConnection conn;
        

        public List<Gender> GetAllGenders()
        {
            conn = dbhandler.GetConnection();
            List<Gender> g = conn.GetAllWithChildren<Gender>();
            conn.Close();
            return g;
        }
        public void InsertGender(Gender gender)
        {
            conn = dbhandler.GetConnection();
            conn.Insert(gender);
            conn.Close();
        }

        public void UpdateGender(Gender gender)
        {
            conn = dbhandler.GetConnection();
            conn.UpdateWithChildren(gender);
            conn.Close();
        }

        public void DeleteGender(Gender gender)
        {
            conn = dbhandler.GetConnection();
            conn.Delete(gender);
            conn.Close();
        }

    }
}
