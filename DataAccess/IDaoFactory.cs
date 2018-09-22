using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDaoFactory
    {
        IParticipantDao ParticipantDao { get; }
        ICategoryDao CategoryDao { get; }
        IDisciplineDao DisciplineDao { get; }
        IStateDao StateDao { get; }
        IGenderDao GenderDao { get; }
    }
}
