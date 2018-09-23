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
    public class ParticipantDao : IParticipantDao
    {
        DBHandler dbHandler = new DBHandler();
        SQLiteConnection conn;

        public List<Participant> GetAllParticipants()
        {
            conn = dbHandler.GetConnection();
            List<Participant> p = conn.GetAllWithChildren<Participant>();
            conn.Close();
            return p;
        }

        public List<Participant> GetParticipantsByCategory(int categoryId)
        {
            conn = dbHandler.GetConnection();
            List<Participant> p = conn.GetAllWithChildren<Participant>(pa => pa.CategoryId == categoryId);
            conn.Close();
            return p;
        }

        public List<Participant> GetParticipantsByGender(int genderId)
        {
            conn = dbHandler.GetConnection();
            List<Participant> p = conn.GetAllWithChildren<Participant>(pa => pa.GenderId == genderId);
            conn.Close();
            return p;
        }

        public List<Participant> GetParticipantsByState(int stateId)
        {
            conn = dbHandler.GetConnection();
            List<Participant> p = conn.GetAllWithChildren<Participant>(pa => pa.StateId == stateId);
            conn.Close();
            return p;
        }

        public Participant GetParticipant(int startNr)
        {
            conn = dbHandler.GetConnection();
            List<Participant> p = conn.GetAllWithChildren<Participant>(pa => pa.Id == startNr);
            conn.Close();

            if (p.Count > 1)
            {
                throw new Exception(String.Format("Mehr als ein Teilnhemer mit der Startnummer {0} gefunden.", startNr));
            }

            return p.FirstOrDefault();
        }

        public void InsertPraticipant(Participant participant)
        {
            conn = dbHandler.GetConnection();
            conn.InsertWithChildren(participant);
            conn.Close();
        }

        public void UpdateParticipant(Participant participant)
        {
            conn = dbHandler.GetConnection();
            conn.UpdateWithChildren(participant);

            CleanUpResultsTable(conn);
            conn.Close();
        }

        public void DeleteParticipant(Participant participant)
        {
            conn = dbHandler.GetConnection();
            conn.Delete<Participant>(participant);

            CleanUpResultsTable(conn);
            conn.Close();
        }

        private void CleanUpResultsTable(SQLiteConnection connection)
        {
            List<Result> results = connection.GetAllWithChildren<Result>(r => r.ParticipantId.Equals(0));

            connection.DeleteAll(results);
        }

        private void CleanUpWarningsTable(SQLiteConnection connection)
        {
            List<Warning> warnings = connection.GetAllWithChildren<Warning>(w => w.ParticipantId.Equals(0) || w.ResultId.Equals(0));
            connection.DeleteAll(warnings);
        }

    }
}
