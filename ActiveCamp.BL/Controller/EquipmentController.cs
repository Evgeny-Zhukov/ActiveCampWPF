using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Controller
{
    internal class EquipmentController
    {
        public Equipment Equipment { get; set;}

        public EquipmentController(Equipment equipment)
        {
            Equipment = equipment;
        }
    }
}
