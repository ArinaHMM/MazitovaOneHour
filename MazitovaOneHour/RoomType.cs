using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazitovaOneHour
{
    public static class RoomType
    {
        public const int Monster = 0;
        public const int Trap = 1;
        public const int Chest = 2;
        public const int Merchant = 3;
        public const int Boss = 4;

        public static string GetRoomTypeName(int type)
        {
            switch (type)
            {
                case Monster:
                    return "Монстр";
                case Trap:
                    return "Ловушка";
                case Chest:
                    return "Сундук";
                case Merchant:
                    return "Торговец";
                case Boss:
                    return "Босс";
                default:
                    return "Неизвестный тип";
            }
        }
    }
}