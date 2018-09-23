using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RanglisteTVO.ViewModels
{
    class ContestOverviewViewModel : ViewModelBase
    {
        private List<Participant> _Participants = App.dbService.GetParticipants();
        public List<Participant> Participants
        {
            get
            {
                return _Participants;
            }
            set
            {
                if (value != _Participants)
                {
                    _Participants = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private List<Category> _Categories = App.dbService.GetCategories();
        public List<Category> Categories
        {
            get
            {
                return _Categories;
            }
            set
            {
                if (value != _Categories)
                {
                    _Categories = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private List<Discipline> _Disciplines = App.dbService.GetDisciplines();
        public List<Discipline> Disciplines
        {
            get
            {
                return _Disciplines;
            }

            set
            {
                if (value != _Disciplines)
                {
                    _Disciplines = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private List<Warning> _Warnings = App.dbService.GetWarnings();
        public List<Warning> Warnings
        {
            get
            {
                return _Warnings;
            }
            set
            {
                if(value != _Warnings)
                {
                    _Warnings = value;
                    NotifyPropertyChanged();
                }
            }
        }

    }
}
