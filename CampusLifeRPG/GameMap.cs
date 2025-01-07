using System;
using System.Collections.Generic;
using CampusLifeRPG.Locations;

namespace CampusLifeRPG
{
    public class GameMap
    {
        private readonly char[,] _map;
        private int _playerX;
        private int _playerY;
        private readonly Dictionary<(int, int), BaseLocation> _locationMap;

        public GameMap()
        {
            _map = new char[,]
            {
                {'╔','═','═','═','═','═','═','═','═','═','═','═','═','═','═','╗'},
                {'║','Y',' ',' ','S',' ',' ','K',' ',' ','C',' ',' ','D',' ','║'},
                {'║',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','║'},
                {'║',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','║'},
                {'║',' ',' ','L',' ',' ',' ','G',' ',' ',' ',' ',' ',' ',' ','║'},
                {'╚','═','═','═','═','═','═','═','═','═','═','═','═','═','═','╝'}
            };

            // Başlangıç pozisyonu (Yurt)
            _playerX = 1;
            _playerY = 1;

            _locationMap = new Dictionary<(int, int), BaseLocation>
            {
                {(1, 1), new Dormitory()},     // Y: Yurt
                {(4, 1), new Classroom()},     // S: Sınıf
                {(7, 1), new Library()},       // K: Kütüphane
                {(10, 1), new Cafeteria()},    // C: Kantin
                {(13, 1), new RecreationArea()}, // D: Dinlenme Alanı
                {(3, 4), new Library()},       // L: Kütüphane
                {(7, 4), new Gym()}           // G: Spor Salonu
            };
        }

        public BaseLocation GetCurrentLocation()
        {
            return _locationMap.TryGetValue((_playerX, _playerY), out var location) ? location : null;
        }

        public void DrawMap()
        {
            Console.Clear();
            for (int y = 0; y < _map.GetLength(0); y++)
            {
                for (int x = 0; x < _map.GetLength(1); x++)
                {
                    if (x == _playerX && y == _playerY)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("♀"); // Kız karakteri temsil eden sembol
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(_map[y, x]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nHarita Açıklaması:");
            Console.WriteLine("Y: Yurt  |  S: Sınıf  |  K: Kütüphane");
            Console.WriteLine("C: Kantin  |  G: Spor Salonu  |  D: Dinlenme Alanı");
            Console.WriteLine("♀: Karakteriniz");
            Console.WriteLine("\nKontroller: W,A,S,D tuşları ile hareket | E: Bulunduğun yerde kal | Q: Çıkış");
        }

        public bool MovePlayer(ConsoleKey key)
        {
            int newX = _playerX;
            int newY = _playerY;

            switch (key)
            {
                case ConsoleKey.W: newY--; break;
                case ConsoleKey.S: newY++; break;
                case ConsoleKey.A: newX--; break;
                case ConsoleKey.D: newX++; break;
            }

            // Harita sınırları ve duvar kontrolü
            if (newX >= 0 && newX < _map.GetLength(1) &&
                newY >= 0 && newY < _map.GetLength(0) &&
                _map[newY, newX] != '║' && _map[newY, newX] != '═' &&
                _map[newY, newX] != '╔' && _map[newY, newX] != '╗' &&
                _map[newY, newX] != '╚' && _map[newY, newX] != '╝')
            {
                _playerX = newX;
                _playerY = newY;
                return true;
            }
            return false;
        }
    }
}
