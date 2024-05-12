using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int FCId { get; set; }
        public Route Route { get; set; }
        public int StringNumber { get; set; }
        public string Dish { get; set; }
        public string ConsumptionTime { get; set; }
        public int DayOfRoute { get; set; }
        public int AmountPerPerson { get; set; }
        public int AmountPerGroup { get; set; }
        #endregion
        public FoodConsumption() { }
        public FoodConsumption(Route route, int stringNumber, string dish, string consumptionTime, int dayOfRoute, int amountPerPerson, int amountPerGroup)
        {
            Route = route;
            StringNumber = stringNumber;
            Dish = dish;
            ConsumptionTime = consumptionTime;
            DayOfRoute = dayOfRoute;
            AmountPerPerson = amountPerPerson;
            AmountPerGroup = amountPerGroup;
        }
    }
}
