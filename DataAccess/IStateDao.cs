using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public interface IStateDao
    {
        List<State> GetStates();

        void InsertState(State state);
        void UpdateState(State state);
        void DeleteState(State state);
    }
}
