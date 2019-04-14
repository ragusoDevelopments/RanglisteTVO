using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavigationEngine.Interfaces;

namespace RanglisteTVO.ViewModels
{
    public class EditObjectsShellViewModel : ViewModelBase, INavigatable
    {
        public struct ObjectDisplay
        {
            public object obj { get; set; }
            public string display { get; set; }
        }

        public EditObjectsShellViewModel()
        {
            #region mock

            Objects.Add(new ObjectDisplay { obj = null, display = "Test01" });
            Objects.Add(new ObjectDisplay { obj = null, display = "Test02" });
            Objects.Add(new ObjectDisplay { obj = null, display = "Test03" });

            #endregion
        }

        private List<ObjectDisplay> _objects = new List<ObjectDisplay>();
        public List<ObjectDisplay> Objects
        {
            get
            {
                return _objects;
            }
            set
            {
                if (value != _objects)
                {
                    _objects = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public object leavingParameter
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void OnEnter(object staticParameter, object dyncamicParameter)
        {

        }

        public bool OnLeaving()
        {
            return true;
        }
    }
}
