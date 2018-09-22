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
    public class StateDao : IStateDao
    {
        DBHandler dbHandler = new DBHandler();
        SQLiteConnection conn;

        public StateDao()
        {
            conn = dbHandler.GetConnection();
        }

        public void DeleteState(State state)
        {
            conn.Delete(state);
        }

        public List<State> GetStates()
        {
            return conn.GetAllWithChildren<State>();
        }

        public void InsertState(State state)
        {
            conn.InsertWithChildren(state);
        }

        public void UpdateState(State state)
        {
            conn.UpdateWithChildren(state);
        }
    }
}
