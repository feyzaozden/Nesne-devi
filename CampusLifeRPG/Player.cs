using System;

namespace CampusLifeRPG
{
    public class Player
    {
        public string Name { get; private set; }
        public int Energy { get; private set; }
        public int Intelligence { get; private set; }
        public int Social { get; private set; }
        public int Health { get; private set; }
        public Location CurrentLocation { get; set; }

        public Player(string name)
        {
            Name = name;
            Energy = 100;
            Intelligence = 50;
            Social = 50;
            Health = 100;
            CurrentLocation = Location.Dormitory;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Karakter Adı: {Name}");
            Console.WriteLine($"Enerji: {Energy}%");
            Console.WriteLine($"Akademik Başarı: {Intelligence}%");
            Console.WriteLine($"Sosyallik: {Social}%");
            Console.WriteLine($"Sağlık: {Health}%");
        }

        public void UpdateStats(int energy, int intelligence, int social, int health)
        {
            Energy = Math.Max(0, Math.Min(100, Energy + energy));
            Intelligence = Math.Max(0, Math.Min(100, Intelligence + intelligence));
            Social = Math.Max(0, Math.Min(100, Social + social));
            Health = Math.Max(0, Math.Min(100, Health + health));
        }

        public void ResetStats()
        {
            Energy = 100;
            Intelligence = 50;
            Social = 50;
            Health = 100;
        }
    }
}
