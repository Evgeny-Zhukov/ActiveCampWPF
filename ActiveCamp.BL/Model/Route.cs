﻿using ActiveCamp.BL.Controller;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{
    public class Route : INotifyPropertyChanged, IEditableObject
    {
        #region Свойства 
        private int _routeId;
        private string _routeName;
        private string _routeDescription;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _startPoint;
        private string _endPoint;
        private int _duration;
        private double _lenght;
        private string _difficulty;
        private int _memberCount;
        private int _authorID;
        private bool _isPrivate;

        /// <summary>
        /// Получает идентификатор маршрута
        /// </summary>
        public int RouteId
        {
            get { return this._routeId; }
            set
            {
                if (value != this._routeId)
                {
                    this._routeId = value;
                    NotifyPropertyChanged("RouteId");
                }
            }
        }

        /// <summary>
        /// Получает название маршрута
        /// </summary>
        public string RouteName
        {
            get { return this._routeName; }
            set
            {
                if (value != this._routeName)
                {
                    this._routeName = value;
                    NotifyPropertyChanged("RouteName");
                }
            }
        }

        /// <summary>
        /// Получает описание маршрута
        /// </summary>
        public string Description
        {
            get { return this._routeDescription; }
            set
            {
                if (value != this._routeDescription)
                {
                    this._routeDescription = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        /// <summary>
        /// Получает дату начала маршрута
        /// </summary>
        public DateTime StartDate
        {
            get { return this._startDate; }
            set
            {
                if (value != this._startDate)
                {
                    this._startDate = value;
                    NotifyPropertyChanged("StartDate");
                }
            }
        }

        /// <summary>
        /// Получает дату окончания маршрута
        /// </summary>
        public DateTime EndDate
        {
            get { return this._endDate; }
            set
            {
                if (value != this._endDate)
                {
                    this._endDate = value;
                    NotifyPropertyChanged("EndDate");
                }
            }
        }

        /// <summary>
        /// Получает начальную точку маршрута
        /// </summary>
        public string StartPoint
        {
            get { return this._startPoint; }
            set
            {
                if (value != this._startPoint)
                {
                    this._startPoint = value;
                    NotifyPropertyChanged("StartPoint");
                }
            }
        }

        /// <summary>
        /// Получает конечную точку маршрута
        /// </summary>
        public string EndPoint
        {
            get { return this._endPoint; }
            set
            {
                if (value != this._endPoint)
                {
                    this._endPoint = value;
                    NotifyPropertyChanged("EndPoint");
                }
            }
        }

        /// <summary>
        /// Получает продолжительность маршрута
        /// </summary>
        public int Duration
        {
            get { return this._duration; }
            set
            {
                if (value != this._duration)
                {
                    this._duration = value;
                    NotifyPropertyChanged("Duration");
                }
            }
        }

        /// <summary>
        /// Получает длину маршрута
        /// </summary>
        public double Length
        {
            get { return this._lenght; }
            set
            {
                if (value != this._lenght)
                {
                    this._lenght = value;
                    NotifyPropertyChanged("Length");
                }
            }
        }

        /// <summary>
        /// Получает сложность маршрута
        /// </summary>
        public string Difficulty
        {
            get { return this._difficulty; }
            set
            {
                if (value != this._difficulty)
                {
                    this._difficulty = value;
                    NotifyPropertyChanged("Difficulty");
                }
            }
        }

        /// <summary>
        /// Количество участников
        /// </summary>
        public int MemberCount
        {
            get { return this._memberCount; }
            set
            {
                if (value != this._memberCount)
                {
                    this._memberCount = value;
                    NotifyPropertyChanged("MemberCount");
                }
            }
        }
        /// <summary>
        /// Получает идентификатор автора маршрута
        /// </summary>
        public int AuthorId
        {
            get { return this._authorID; }
            set
            {
                if (value != this._authorID)
                {
                    this._authorID = value;
                    NotifyPropertyChanged("AuthorId");
                }
            }
        }

        /// <summary>
        /// Получает значение, является ли маршрут приватным
        /// </summary>
        public bool IsPrivate
        {
            get { return this._isPrivate; }
            set
            {
                if (value != this._isPrivate)
                {
                    this._isPrivate = value;
                    NotifyPropertyChanged("IsPrivate");
                }
            }
        }
        #endregion
        public Route()
        {
        }

        /// <summary>
        /// Конструктор для маршрута с датами и описанием
        /// </summary>
        /// <param name="startDate">Дата начала</param>
        /// <param name="endDate">Дата окончания</param>
        /// <param name="description">Описание</param>
        /// <param name="startPoint">Начальная точка</param>
        /// <param name="endPoint">Конечная точка</param>
        /// <param name="difficulty">Сложность</param>
        /// <param name="isPrivate">Приватный маршрут</param>
        public Route(DateTime startDate, DateTime endDate, string description, string startPoint, string endPoint, string difficulty,  int memberCount, bool isPrivate)
        {
            this._startDate = startDate;
            this._endDate = endDate;
            this._routeDescription = description;
            this._startPoint = startPoint;
            this._endPoint = endPoint;
            this._difficulty = difficulty;
            this._memberCount = memberCount;
            this._isPrivate = isPrivate;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private Route temp_Record = null;
        private bool m_Editing = false;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as Route;
                m_Editing = true;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                _routeId = temp_Record.RouteId;
                _routeName = temp_Record.RouteName;
                _routeDescription = temp_Record.Description;
                _startDate = temp_Record.StartDate;
                _endDate = temp_Record.EndDate;
                _startPoint = temp_Record.StartPoint;
                _endPoint = temp_Record.EndPoint;
                _duration = temp_Record.Duration;
                _lenght = temp_Record.Length;
                _difficulty = temp_Record.Difficulty;
                _memberCount = temp_Record.MemberCount;
                _authorID = temp_Record.AuthorId;

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
