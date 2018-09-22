using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public interface IParticipantDao
    {
        List<Participant> GetAllParticipants();
        List<Participant> GetParticipantsByCategory(int categoryId);
        List<Participant> GetParticipantsByState(int stateId);
        List<Participant> GetParticipantsByGender(int genderId);
        Participant GetParticipant(int startNr);

        void InsertPraticipant(Participant participant);
        void UpdateParticipant(Participant participant);
        void DeleteParticipant(Participant participant);
    }
}
