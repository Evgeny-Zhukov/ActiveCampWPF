
using System;

namespace ActiveCamp.BL.Model
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    public class FoodConsumption
    {
        #region Свойства
        /// <summary>
        /// ИД
        /// </summary>
        public int FCId { get; private set; }
        /// <summary>
        /// К какому маршруту относится
        /// </summary>
        public int RouteID { get; private set; }
        /// <summary>
        /// Номер строки
        /// </summary>
        public int StringNumber { get; private set; }
        /// <summary>
        /// Еда
        /// </summary>
        public string Dish { get; private set; }
        /// <summary>
        /// Время приема пищи
        /// </summary>
        public string ConsumptionTime { get; private set; }
        /// <summary>
        /// День маршрута
        /// </summary>
        public int DayOfRoute { get; private set; }
        /// <summary>
        /// Количество на человека
        /// </summary>
        public int AmountPerPerson { get; private set; }
        /// <summary>
        /// Количество на группу
        /// </summary>
        public int AmountPerGroup { get; private set; }
        #endregion
        public FoodConsumption() { }
        public FoodConsumption(int route, int stringNumber, string dish, string consumptionTime, int dayOfRoute, int amountPerPerson, int amountPerGroup)
        {
            RouteID = route;
            StringNumber = stringNumber;
            Dish = dish;
            ConsumptionTime = consumptionTime;
            DayOfRoute = dayOfRoute;
            AmountPerPerson = amountPerPerson;
            AmountPerGroup = amountPerGroup;
        }
        public void SetRoute(int route)
        {
            if (route <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(RouteID), "Маршрут не может быть пустым или NULL");
            }
            RouteID = route;
        }

        public void SetStringNumber(int stringNumber)
        {
            if (stringNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stringNumber), "Номер строки должен быть положительным числом.");
            }
            StringNumber = stringNumber;
        }

        public void SetDish(string dish)
        {
            Dish = dish ?? throw new ArgumentNullException(nameof(dish), "Блюдо не может быть пустым или NULL");
        }

        public void SetConsumptionTime(string consumptionTime)
        {
            ConsumptionTime = consumptionTime ?? throw new ArgumentNullException(nameof(consumptionTime), "Время потребления не может быть пустым или NULL");
        }

        public void SetDayOfRoute(int dayOfRoute)
        {
            if (dayOfRoute <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dayOfRoute), "День маршрута должен быть положительным числом.");
            }
            DayOfRoute = dayOfRoute;
        }

        public void SetAmountPerPerson(int amountPerPerson)
        {
            if (amountPerPerson <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amountPerPerson), "Количество на человека должно быть положительным числом.");
            }
            AmountPerPerson = amountPerPerson;
        }

        public void SetAmountPerGroup(int amountPerGroup)
        {
            if (amountPerGroup <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amountPerGroup), "Количество на группу должно быть положительным числом.");
            }
            AmountPerGroup = amountPerGroup;
        }
        public void SetFCId(int fcId)
        {
            if (fcId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(fcId), "ID должен быть положительным числом.");
            }
            FCId = fcId;
        }
    }
}
