using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazitovaOneHour
{

    using System;

    namespace NumericalQuestPlus
    {
        class Game
        {
            private Player player;
            private Room[] dungeonMap;
            private Random random;

            public Game()
            {
                random = new Random();
                player = new Player();
                dungeonMap = new Room[10];
                InitializeDungeon();
            }

            private void InitializeDungeon()
            {
                for (int i = 0; i < 9; i++)
                {
                    dungeonMap[i] = new Room(random.Next(0, 4)); 
                }
                dungeonMap[9] = new Room(4); 
            }

            public void Start()
            {
                Console.WriteLine("Добро пожаловать в Числовой квест PLUS! Как вас зовут?");
                string name = Console.ReadLine();
                Console.WriteLine("Ваша цель - пройти 10 комнат и победить босса.");
                Console.WriteLine("Ваше снаряжение \n" + "Здоровье:" + player.Health +"\n" + "Золото: " +  player.Gold + "\n" + "Стрелы:" +  player.Arrows + "\n");

                Console.WriteLine("Удачи," + name);
                

                for (int i = 0; i < dungeonMap.Length; i++)
                {
                    Console.WriteLine($"Вы входите в комнату {i + 1}...");
                    EnterRoom(dungeonMap[i]);
                    if (player.Health <= 0)
                    {
                        Console.WriteLine("Вы погибли. Игра окончена.");
                        EndGame();
                        return;
                    }
                }

                Console.WriteLine("Поздравляем! Вы победили босса и завершили игру!");
                EndGame();
            }
            private void EndGame()
            {
                Console.WriteLine("Нажмите enter чтобы выйти из игры");
                Console.ReadLine();

            }

            private void EnterRoom(Room room)
            {
                switch (room.Type)
                {
                    case RoomType.Monster:
                        FightMonster();
                        break;
                    case RoomType.Trap:
                        HitTrap();
                        break;
                    case RoomType.Chest:
                        OpenChest();
                        break;
                    case RoomType.Merchant:
                        MeetMerchant();
                        break;
                    case RoomType.Boss:
                        FightBoss();
                        break;
                    default:
                        Console.WriteLine("Эта комната пуста.");
                        break;
                }
            }

            private void FightMonster()
            {
                int monsterHealth = random.Next(20, 51);
                Console.WriteLine($"Вы встретили монстра с {monsterHealth} HP!  Ваше здоровье составляет:" + player.Health);

                while (monsterHealth > 0 && player.Health > 0)
                {
                    Console.WriteLine("Выберите оружие: 1 - Меч, 2 - Лук");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        int damage = random.Next(10, 21);
                        monsterHealth -= damage;
                        Console.WriteLine($"Вы нанесли {damage} урона мечом.");
                    }
                    else if (choice == 2)
                    {
                        if (player.Arrows > 0)
                        {
                            int damage = random.Next(5, 16);
                            monsterHealth -= damage;
                            player.Arrows--;
                            Console.WriteLine($"Вы нанесли {damage} урона луком." + "Стрел осталось:" + player.Arrows);
                        }
                        if (player.Arrows <= 0)
                        {
                            int damage = 0;
                            monsterHealth -= damage;
                            player.Arrows--;
                            Console.WriteLine($"Вы нанесли урона {damage} потому что стрелы закончились! Сражайтесь мечом!!!");
                        }
                        else
                        {
                            Console.WriteLine("У вас закончились стрелы!");
                        }
                    }
                    else if (choice == 3)
                    {
                        player.UsePot();
                    }


                    if (monsterHealth > 0)
                    {
                        int monsterDamage = random.Next(5, 16);
                        player.Health -= monsterDamage;
                        Console.WriteLine($"Монстр нанес вам {monsterDamage} урона. Ваше здоровье составляет:" + player.Health);
                    }
                }

                if (player.Health > 0)
                {
                    Console.WriteLine("Вы победили монстра!");
                }
                

            }

            private void HitTrap()
            {
                int trapDamage = random.Next(10, 21);
                player.Health -= trapDamage;
                
                
            }

            private void OpenChest()
            {
                Console.WriteLine("Вы нашли сундук! Чтобы открыть его, решите загадку:");
                int a = random.Next(1, 11);
                int b = random.Next(1, 11);


                Console.WriteLine($"Сколько будет {a} + {b}?");
                int answer = int.Parse(Console.ReadLine());

                if (answer == a + b)
                {
                    Console.WriteLine("Правильно! Вы получаете награду.");
                    int reward = random.Next(1, 4);
                    switch (reward)
                    {
                        case 1:
                            player.Potions++;
                            Console.WriteLine("Вы нашли зелье! Теперь у вас " + player.Potions );
                            break;
                        case 2:
                            player.Gold += 20;
                            Console.WriteLine("Вы нашли 20 золота!");
                            break;
                        case 3:
                            player.Arrows += 5;
                            Console.WriteLine("Вы нашли 5 стрел!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неправильно! Сундук остается закрытым.");
                }
            }
            

            private void MeetMerchant()
            {
                Console.WriteLine("Вы встретили торговца. Он предлагает зелье за 30 золота.");
                Console.WriteLine("Ваше золото: " + player.Gold);
                Console.WriteLine("Купить зелье? (1 - Да, 2 - Нет)");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1 && player.Gold >= 30)
                {
                    player.Gold -= 30;
                    player.Potions++;
                    Console.WriteLine("Вы купили зелье! Теперь у вас " + player.Potions );
                }
                else
                {
                    Console.WriteLine("У вас недостаточно золота или вы отказались от покупки.");
                }
            }

            private void FightBoss()
            {
                int bossHealth = 100;
                Console.WriteLine("Вы встретили босса с 100 HP!");

                while (bossHealth > 0 && player.Health > 0)
                {
                    Console.WriteLine("Выберите оружие: 1 - Меч, 2 - Лук");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        int damage = random.Next(10, 21);
                        bossHealth -= damage;
                        Console.WriteLine($"Вы нанесли {damage} урона мечом.");
                    }
                    else if (choice == 2)
                    {
                        if (player.Arrows > 0)
                        {
                            int damage = random.Next(5, 16);
                            bossHealth -= damage;
                            player.Arrows--;
                            Console.WriteLine($"Вы нанесли {damage} урона луком.");
                        }
                        else
                        {
                            Console.WriteLine("У вас закончились стрелы!");
                        }
                    }
                    
                    if (bossHealth > 0)
                    {
                        int bossDamage = random.Next(15, 26);
                        player.Health -= bossDamage;
                        Console.WriteLine($"Босс нанес вам {bossDamage} урона. Ваше здоровье составляет:" + player.Health);
                    }
                    

                }

                if (player.Health > 0)
                {
                    Console.WriteLine("Вы победили босса!");
                    EndGame();
                }
                if (player.Health < 0)
                {
                    player.Health = 0;
                }
                if (player.Health == 0 || player.Health <0)
                {
                    Console.WriteLine($"Босс нанес вам решающий урон. Вы ПРОИГРАЛИ");
                    EndGame();

                }
            }
        }
    }
}

