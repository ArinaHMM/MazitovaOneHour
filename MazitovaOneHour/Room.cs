using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazitovaOneHour
{
     class Room
    {
        public int Type { get;  }
        public Room(int type)
        {
            Type = type;
        }
        public string DescritpiOon()
        {
            return RoomType.GetRoomTypeName(Type);
        }
    }
}
