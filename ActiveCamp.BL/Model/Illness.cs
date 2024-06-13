using ActiveCamp.BL.Controller;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{
    /// <summary>
    /// Недуг.
    /// </summary>
    public class Illness : INotifyPropertyChanged, IEditableObject
    {
        #region Свойства
        private int _illnessID;
        private string _illnessName;
        private string _illnessDescription;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// ИД недуга.
        /// </summary>
        public int IllnessID
        {
            get { return this._illnessID; }
            set
            {
                if (value != this._illnessID)
                {
                    this._illnessID = value;
                    NotifyPropertyChanged("IllnessID");
                }
            }
        }

        /// <summary>
        /// Название недуга.
        /// </summary>
        public string IllnessName
        {
            get { return this._illnessName; }
            set
            {
                if (value != this._illnessName)
                {
                    this._illnessName = value;
                    NotifyPropertyChanged("IllnessName");
                }
            }
        }

        /// <summary>
        /// Описание недуга.
        /// </summary>
        public string IllnessDescription
        {
            get { return this._illnessDescription; }
            set
            {
                if (value != this._illnessDescription)
                {
                    this._illnessDescription = value;
                    NotifyPropertyChanged("IllnessDescription");
                }
            }
        }
        #endregion

        public Illness() { }

        /// <summary>
        /// Создает недуг.
        /// </summary>
        /// <param name="name">Название недуга</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Illness(string name)
        {
            this._illnessName = name ?? throw new ArgumentNullException("Название недуга не может быть пустым или NULL", nameof(name));
        }
        public Illness(string name, string description)
        {
            this._illnessName = name ?? throw new ArgumentNullException("Название недуга не может быть пустым или NULL", nameof(name));
            this._illnessDescription = description ?? throw new ArgumentNullException("Описание недуга не может быть пустым или NULL", nameof(description));
        }
        private Illness temp_Record = null;
        private bool m_Editing = false;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as Illness;
                m_Editing = true;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                _illnessID = temp_Record._illnessID;
                _illnessName = temp_Record._illnessName;
                _illnessDescription = temp_Record._illnessDescription;

                m_Editing = false;
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
