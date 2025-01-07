﻿namespace CampusLifeRPG.Locations
{
    public class Gym : BaseLocation
    {
        public Gym()
        {
            Name = "Spor Salonu";
        }

        public override void Visit(Player player)
        {
            UpdatePlayerStats(player,
                energy: -60,    // Enerji azalır
                intelligence: 0,
                social: 20,     // Sosyallik biraz artar
                health: 40);    // Sağlık çok artar

            System.Console.WriteLine("Spor salonunda iyi bir antrenman yaptınız. Sağlığınız arttı ama yoruldunuz.");
        }
    }
}
