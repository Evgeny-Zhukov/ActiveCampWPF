using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    public class Experience : INotifyPropertyChanged, IEditableObject
    {
        private int _experienceID;
        private int _routeID;

        public int ExperienceID
        {
            get { return this._experienceID; }
            set
            {
                if (value != this._experienceID)
                {
                    this._experienceID = value;
                    NotifyPropertyChanged("ExperienceID");
                }
            }
        }
        public int RouteID
        {
            get { return this._routeID; }
            set
            {
                if (value != this._routeID)
                {
                    this._routeID = value;
                    NotifyPropertyChanged("RouteID");
                }
            }
        }

        public Experience() { }
        public Experience(int routeID)
        {
            this._routeID = routeID;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Experience temp_Record = null;
        private bool m_Editing = false;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as Experience;
                m_Editing = true;
            }
        }

        public void EndEdit()
        {
            if (!m_Editing == true)
            {
                _experienceID = temp_Record._experienceID;
                _routeID = temp_Record._routeID;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                temp_Record = null;
                m_Editing = false;
            }
        }
    }
}
