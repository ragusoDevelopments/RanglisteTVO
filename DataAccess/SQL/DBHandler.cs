using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using SQLiteNetExtensions.Extensions;
using Models;

namespace DataAccess.SQL
{
    public class DBHandler : IDBHandler
    {
        public SQLite.SQLiteConnection getConnection()
        {
            if (!File.Exists(Environment.CurrentDirectory + "testDB.sqlite"))
            {
                SQLiteConnection connection = new SQLiteConnection(Environment.CurrentDirectory + "testDB.sqlite");
                connection.Execute("PRAGMA foreign_keys = ON;");
                connection.CreateTable<Participant>();
                connection.CreateTable<Result>();
                connection.CreateTable<Category>();
                connection.CreateTable<Discipline>();
                connection.CreateTable<DisciplineValue>();
                return connection;
            }
            else
            {
                return new SQLite.SQLiteConnection(Environment.CurrentDirectory + "testDB.sqlite");
            }
        }

    }
}
