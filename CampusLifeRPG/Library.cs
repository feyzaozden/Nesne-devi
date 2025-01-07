namespace CampusLifeRPG.Locations
{
    public class Library : BaseLocation
    {
        public Library()
        {
            Name = "Kütüphane";
        }

        public override void Visit(Player player)
        {
            UpdatePlayerStats(player,
                energy: -30,     // Enerji azalır
                intelligence: 40, // Akademik başarı artar
                social: -30,     // Sosyallik azalır
                health: -20);     // Sağlık biraz azalır

            System.Console.WriteLine("Kütüphanede sessizce ders çalıştınız. Akademik başarınız arttı ama sosyalliğiniz azaldı.");
        }
    }
}
