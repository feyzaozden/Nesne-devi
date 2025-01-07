namespace CampusLifeRPG.Locations
{
    public class Cafeteria : BaseLocation
    {
        public Cafeteria()
        {
            Name = "Kantin";
        }

        public override void Visit(Player player)
        {
            UpdatePlayerStats(player,
                energy: -30,    // Enerji biraz azalır
                intelligence: 0,
                social: 50,     // Sosyallik artar
                health: 30);    // Sağlık artar

            System.Console.WriteLine("Kantinde güzel bir yemek yediniz ve arkadaşlarınızla sohbet ettiniz. Sağlığınız ve sosyalliğiniz arttı.");
        }
    }
}
