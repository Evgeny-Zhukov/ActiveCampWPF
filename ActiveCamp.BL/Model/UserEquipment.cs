using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    internal class UserEquipment
    {
        public int UserEquipmentID { get; set; }
        public int UserID { get; set; }
        public int EquipmentID { get; set; }
        public UserEquipment() { }
    }
}
