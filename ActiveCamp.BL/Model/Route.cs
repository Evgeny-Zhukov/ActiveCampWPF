using ActiveCamp.BL.Controller;
using System;

namespace ActiveCamp.BL.Model
{
    public class Route
    {
        /// <summary>
        /// Получает идентификатор маршрута
        /// </summary>
        public int RouteId { get; private set; }

        /// <summary>
        /// Получает название маршрута
        /// </summary>
        public string RouteName { get; private set; }

        /// <summary>
        /// Получает описание маршрута
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Получает дату начала маршрута
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Получает дату окончания маршрута
        /// </summary>
        public DateTime EndDate { get; private set; }

        /// <summary>
        /// Получает начальную точку маршрута
        /// </summary>
        public string StartPoint { get; private set; }

        /// <summary>
        /// Получает конечную точку маршрута
        /// </summary>
        public string EndPoint { get; private set; }

        /// <summary>
        /// Получает продолжительность маршрута
        /// </summary>
        public int Duration { get; private set; }

        /// <summary>
        /// Получает длину маршрута
        /// </summary>
        public double Length { get; private set; }

        /// <summary>
        /// Получает сложность маршрута
        /// </summary>
        public string Difficulty { get; private set; }

        /// <summary>
        /// Получает идентификатор автора маршрута
        /// </summary>
        public int AuthorId { get; private set; }

        /// <summary>
        /// Получает значение, является ли маршрут приватным
        /// </summary>
        public bool IsPrivate { get; private set; }

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
        public Route(DateTime startDate, DateTime endDate, string description, string startPoint, string endPoint, string difficulty, bool isPrivate)
        {
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            StartPoint = startPoint;
            EndPoint = endPoint;
            Difficulty = difficulty;
            IsPrivate = isPrivate;
        }

        /// <summary>
        /// Конструктор для маршрута с названием, продолжительностью и автором
        /// </summary>
        /// <param name="routeName">Название маршрута</param>
        /// <param name="duration">Продолжительность</param>
        /// <param name="length">Длина маршрута</param>
        /// <param name="difficulty">Сложность</param>
        /// <param name="authorId">Идентификатор автора</param>
        public Route(string routeName, int duration, double length, string difficulty, int authorId)
        {
            RouteName = routeName;
            Duration = duration;
            Length = length;
            Difficulty = difficulty;
            AuthorId = authorId;
        }

        /// <summary>
        /// Устанавливает идентификатор маршрута
        /// </summary>
        /// <param name="routeId">Идентификатор маршрута</param>
        public void SetRouteId(Route route)
        {
            RouteManager routeManager = new RouteManager();
            int routeID = routeManager.GetRouteID(route);
            RouteId = routeID;
        }

        /// <summary>
        /// Устанавливает название маршрута
        /// </summary>
        /// <param name="routeName">Название маршрута</param>
        public void SetRouteName(string routeName)
        {
            RouteName = routeName;
        }

        /// <summary>
        /// Устанавливает описание маршрута
        /// </summary>
        /// <param name="description">Описание</param>
        public void SetDescription(string description)
        {
            Description = description;
        }

        /// <summary>
        /// Устанавливает дату начала маршрута
        /// </summary>
        /// <param name="startDate">Дата начала</param>
        public void SetStartDate(DateTime startDate)
        {
            StartDate = startDate;
        }

        /// <summary>
        /// Устанавливает дату окончания маршрута
        /// </summary>
        /// <param name="endDate">Дата окончания</param>
        public void SetEndDate(DateTime endDate)
        {
            EndDate = endDate;
        }

        /// <summary>
        /// Устанавливает начальную точку маршрута
        /// </summary>
        /// <param name="startPoint">Начальная точка</param>
        public void SetStartPoint(string startPoint)
        {
            StartPoint = startPoint;
        }

        /// <summary>
        /// Устанавливает конечную точку маршрута
        /// </summary>
        /// <param name="endPoint">Конечная точка</param>
        public void SetEndPoint(string endPoint)
        {
            EndPoint = endPoint;
        }

        /// <summary>
        /// Устанавливает продолжительность маршрута
        /// </summary>
        /// <param name="duration">Продолжительность</param>
        public void SetDuration(int duration)
        {
            Duration = duration;
        }

        /// <summary>
        /// Устанавливает длину маршрута
        /// </summary>
        /// <param name="length">Длина маршрута</param>
        public void SetLength(double length)
        {
            Length = length;
        }

        /// <summary>
        /// Устанавливает сложность маршрута
        /// </summary>
        /// <param name="difficulty">Сложность</param>
        public void SetDifficulty(string difficulty)
        {
            Difficulty = difficulty;
        }

        /// <summary>
        /// Устанавливает идентификатор автора маршрута
        /// </summary>
        /// <param name="authorId">Идентификатор автора</param>
        public void SetAuthorId(int authorId)
        {
            AuthorId = authorId;
        }

        /// <summary>
        /// Устанавливает значение приватности маршрута
        /// </summary>
        /// <param name="isPrivate">Приватный маршрут</param>
        public void SetIsPrivate(bool isPrivate)
        {
            IsPrivate = isPrivate;
        }
    }


}
