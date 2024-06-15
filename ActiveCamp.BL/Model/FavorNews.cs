using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    public class FavorNews
    {
        private int _favorNewsID;
        private int _authorID;
        private int _newsID;


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
        public int FavorNewsID
        {
            get { return this._favorNewsID; }
            set
            {
                if (value != this._favorNewsID)
                {
                    this._favorNewsID = value;
                    NotifyPropertyChanged("FavorNewsID");
                }
            }
        }
        
        public FavorNews() { }
        public FavorNews(int authorID, int newsID)
        {
            this._authorID= authorID;
            this._newsID = newsID;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private FavorNews temp_Record = null;
        private bool m_Editing = false;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as FavorNews;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _newsID = temp_Record._newsID;
                _authorID = temp_Record._authorID;
                _newsID = temp_Record.NewsID;

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
