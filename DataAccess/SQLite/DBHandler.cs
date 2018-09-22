using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using SQLiteNetExtensions.Extensions;
using Models;

namespace DataAccess.SQLite
{
    public class DBHandler : IDBHandler
    {
        public string DBFilePath { get; set; } = null;

        public SQLiteConnection GetConnection()
        {
            if(DBFilePath == null)
            {
                throw new Exception("The path to the Database is not set. Please do that by setting the DBHelper.DBFilePath property");
            }

            if (!File.Exists(DBFilePath))
            {
                SQLiteConnection connection = new SQLiteConnection(DBFilePath);
                connection.Execute("PRAGMA FOREIGN_KEYS = ON;");
                connection.CreateTable<Participant>();
                connection.CreateTable<Result>();
                connection.CreateTable<Category>();
                connection.CreateTable<Discipline>();
                connection.CreateTable<DisciplineValue>();
                connection.CreateTable<State>();
                connection.CreateTable<Gender>();
                return connection;
            }
            else
            {
                return new SQLiteConnection(DBFilePath);
            }
        }

    }
}
