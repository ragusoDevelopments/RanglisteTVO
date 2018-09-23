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
        private string _DBFilePath = null;
        public string DBFilePath
        {
            get
            {
                return _DBFilePath;
            }
            set
            {
                if(_DBFilePath != value)
                {
                    _DBFilePath = value;
                }
            }
        }

        public SQLiteConnection GetConnection()
        {
            //Test
            DBFilePath = Environment.CurrentDirectory + "\\TestDB.sqlite";
            if (DBFilePath == null)
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
                connection.CreateTable<Warning>();
                return connection;
            }
            else
            {
                return new SQLiteConnection(DBFilePath);
            }
        }

    }
}
