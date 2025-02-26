using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazitovaOneHour
{
     class Player
    {
        public int Health { get; set; } = 100;
        public int health
        {
            get { return Health; }
            set { 
                Health = value; 
                if(health < 0)
                {
                    health = 0;
                }
                if (health > 100)
                {
                    health = 100;
                }
            }
        }
        public int Potions { get; set; } = 3;
        public int Gold { get; set; } = 0;
        public int Arrows { get; set; } = 5;

        public void UsePot()
        {
            if(Potions > 0)
            {
                Health += 10;
                Potions--;
                Console.WriteLine("Вы восстановили 10 здоровья!");
                else
                {
                    Console.WriteLine("Нет зелий!");
                }
            }
        }
    }
}
