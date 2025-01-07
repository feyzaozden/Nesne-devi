using System;
using System.Collections.Generic;

namespace CampusLifeRPG
{
    public class Map
    {
        private readonly Location[,] grid;
        private int playerX;
        private int playerY;
        private int lastX;
        private int lastY;

        public Map()
        {
            grid = new Location[5, 5]
            {
                { Location.EmptySpace, Location.EmptySpace, Location.Classroom, Location.EmptySpace, Location.EmptySpace },
                { Location.EmptySpace, Location.Library, Location.EmptySpace, Location.Gym, Location.EmptySpace },
                { Location.Cafeteria, Location.EmptySpace, Location.Dormitory, Location.EmptySpace, Location.RecreationArea },
                { Location.EmptySpace, Location.Library, Location.EmptySpace, Location.Gym, Location.EmptySpace },
                { Location.EmptySpace, Location.EmptySpace, Location.Classroom, Location.EmptySpace, Location.EmptySpace }
            };

            playerX = 2;
            playerY = 2;
            lastX = playerX;
            lastY = playerY;
        }

        public void PrintMap()
        {
            Console.WriteLine("\nKampüs Haritası:");
            Console.WriteLine("(W/A/S/D tuşları ile hareket edin)\n");

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.Write("P ");
                        continue;
                    }

                    switch (grid[y, x])
                    {
                        case Location.Dormitory:
                            Console.Write("Y "); // Yurt
                            break;
                        case Location.Classroom:
                            Console.Write("S "); // Sınıf
                            break;
                        case Location.Library:
                            Console.Write("K "); // Kütüphane
                            break;
                        case Location.Cafeteria:
                            Console.Write("C "); // Kantin
                            break;
                        case Location.Gym:
                            Console.Write("G "); // Spor Salonu
                            break;
                        case Location.RecreationArea:
                            Console.Write("D "); // Dinlenme Alanı
                            break;
                        case Location.EmptySpace:
                            Console.Write(". ");
                            break;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nHarita Açıklaması:");
            Console.WriteLine("P: Oyuncu,Y:Yurt,S:Sınıf,K:Kütüphane,C:Kantin,G:Spor Salonu,D:Dinlenme Alanı,.:Boş Alan");
            //Console.WriteLine("Y: Yurt");
            //Console.WriteLine("S: Sınıf");
            //Console.WriteLine("K: Kütüphane");
            //Console.WriteLine("C: Kantin");
            //Console.WriteLine("G: Spor Salonu");
            //Console.WriteLine("D: Dinlenme Alanı");
            //Console.WriteLine(".: Boş Alan");
        }

        public void UndoMove()
        {
            playerX = lastX;
            playerY = lastY;
        }

        public bool MovePlayer(string direction)
        {
            lastX = playerX;
            lastY = playerY;

            switch (direction.ToLower())
            {
                case "w":
                    if (playerY > 0)
                        playerY--;
                    else
                        return false;
                    break;
                case "s":
                    if (playerY < 4)
                        playerY++;
                    else
                        return false;
                    break;
                case "a":
                    if (playerX > 0)
                        playerX--;
                    else
                        return false;
                    break;
                case "d":
                    if (playerX < 4)
                        playerX++;
                    else
                        return false;
                    break;
                default:
                    return false;
            }

            return true;
        }

        public Location GetCurrentLocation()
        {
            return grid[playerY, playerX];
        }
    }
}
