using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    internal class UserIllness
    {
        public int UserIllnessId { get; set; }
        public int UserID {  get; set; }
        public int IllnessID { get; set; }
        public UserIllness() { }
    }
}
