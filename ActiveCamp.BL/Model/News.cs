using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace ActiveCamp.BL.Model
{
    public class News : INotifyPropertyChanged, IEditableObject
    {
        private int _newsID;
        private int _authorID;
        private string _newsText;
        private DateTime _newsDate;
        private bool _isAdminNews;

        public int NewsID
        {
                get { return this._newsID; }
                set
                {
                    if (value != this._newsID)
                    {
                        this._newsID = value;
                        NotifyPropertyChanged("NewsID");
                    }
                }
        }
        public int AuthorID
        {
            get { return this._authorID; }
            set
            {
                if (value != this._authorID)
                {
                    this._authorID = value;
                    NotifyPropertyChanged("AuthorID");
                }
            }
        }
        public string NewsText
        {
            get { return this._newsText; }
            set
            {
                if (value != this._newsText)
                {
                    this._newsText = value;
                    NotifyPropertyChanged("NewsText");
                }
            }
        }
        public DateTime NewsDate
        {
            get { return this._newsDate; }
            set
            {
                if (value != this._newsDate)
                {
                    this._newsDate = value;
                    NotifyPropertyChanged("NewsDate");
                }
            }
        }
        public bool IsAdminNews
        {
            get { return this._isAdminNews; }
            set
            {
                if (value != this._isAdminNews)
                {
                    this._isAdminNews = value;
                    NotifyPropertyChanged("IsAdminNews");
                }
            }
        }
        public News() { }
        public News(int authorID, string newsText, DateTime newsDate, bool isAdminNews)
        {
            this._authorID = authorID;
            this._newsText = newsText;
            this._newsDate = newsDate;
            this._isAdminNews = isAdminNews;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        private News temp_Record = null;
        private bool m_Editing = false;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as News;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _newsID = temp_Record._newsID;
                _authorID = temp_Record._authorID;
                _newsText = temp_Record._newsText;
                _newsDate = temp_Record._newsDate;
                _isAdminNews = temp_Record._isAdminNews;

                m_Editing = false;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                temp_Record = null;
                m_Editing = false;
            }
        }
    }
}
