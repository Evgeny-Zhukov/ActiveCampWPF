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
    public class FoodConsuption
    {
        #region Свойства
        /// <summary>
        /// ИД
        /// </summary>
        public int FCId { get; set; }
        public Route Route { get; set; }
        public int StringNumber { get; set; }
        public string Dish { get; set; }
        public string ConsuptionTime { get; set; }
        public int DayOfRoute { get; set; }
        public int AmountPerPerson { get; set; }
        public int AmountPerGroup { get; set; }
        #endregion
        public FoodConsuption() { }
        public FoodConsuption(Route route, int stringNumber, string dish, string consuptionTime, int dayOfRoute, int amountPerPerson, int amountPerGroup)
        {
            Route = route;
            StringNumber = stringNumber;
            Dish = dish;
            ConsuptionTime = consuptionTime;
            DayOfRoute = dayOfRoute;
            AmountPerPerson = amountPerPerson;
            AmountPerGroup = amountPerGroup;
        }
    }
}
