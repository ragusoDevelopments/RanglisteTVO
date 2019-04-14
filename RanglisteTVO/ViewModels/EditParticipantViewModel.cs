using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Models;
using NavigationEngine.Interfaces;

namespace RanglisteTVO.ViewModels
{
    public class EditParticipantViewModel : ViewModelBase, INavigatable 
    {
        public EditParticipantViewModel()
        {
            #region Mock
            CurrentParticipant = new Participant
            {
                FirstName = "John",
                LastName = "Doe",
                Gender = new Gender { Name = "Männlich"},
                CategoryId = 0,
                YearOfBirth = 2010,
                Results = new List<Result>()
            };

            #endregion

        }

        public Participant _currentParticipant;
        public Participant CurrentParticipant
        {
            get
            {
                return _currentParticipant;
            }
            set
            {
                if (_currentParticipant != value)
                {
                    _currentParticipant = value;
                    NotifyPropertyChanged("CurrentParticipant");
                }
            }
        }

        private object _leavingParameter = null;
        public object leavingParameter
        {
            get
            {
                return _leavingParameter;
            }

            set
            {
                _leavingParameter = value;
            }
        }

        public bool OnLeaving()
        {
            return true;
        }

        public void OnEnter(object staticParameter, object dyncamicParameter)
        {
            throw new NotImplementedException();
        }
    }
}
