using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public interface IGenderDao
    {
        List<Gender> GetAllGenders();
        void InsertGender(Gender gender);
        void UpdateGender(Gender gender);
        void DeleteGender(Gender gender);
    }
}
