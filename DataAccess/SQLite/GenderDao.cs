﻿using System;
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
        DBHandler dbHandler;
        SQLiteConnection conn;

        public GenderDao(string dataPath)
        {
            dbHandler = new DBHandler(dataPath);
            conn = dbHandler.GetConnection();
        }

        public List<Gender> GetAllGenders()
        {
            conn = dbHandler.GetConnection();
            List<Gender> g = conn.GetAllWithChildren<Gender>();
            conn.Close();
            return g;
        }
        public void InsertGender(Gender gender)
        {
            conn = dbHandler.GetConnection();
            conn.Insert(gender);
            conn.Close();
        }

        public void UpdateGender(Gender gender)
        {
            conn = dbHandler.GetConnection();
            conn.UpdateWithChildren(gender);
            conn.Close();
        }

        public void DeleteGender(Gender gender)
        {
            conn = dbHandler.GetConnection();
            conn.Delete(gender);
            conn.Close();
        }

    }
}
