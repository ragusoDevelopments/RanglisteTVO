using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationEngine.Interfaces
{
    public interface INavigatable
    {
        void OnEnter(object staticParameter, object dyncamicParameter);
        bool OnLeaving();

        object leavingParameter { get; set; }
    }
}
