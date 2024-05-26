using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Controller
{
    internal class EquipmentController
    {
        public Dish Equipment { get; set;}

        public EquipmentController(Dish equipment)
        {
            Equipment = equipment;
        }
    }
}
