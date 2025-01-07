using System.Xml.Linq;

namespace CampusLifeRPG.Locations
{
    public class Dormitory : BaseLocation
    {
        public Dormitory()
        {
            Name = "Yurt";
        }

        public override void Visit(Player player)
        {
            UpdatePlayerStats(player,
                energy: 50,      // Enerji artar
                intelligence: 0,
                social: -30,     // Sosyallik azalır
                health: 30);     // Sağlık biraz artar

            System.Console.WriteLine("Yurtta dinleniyorsunuz. Enerji seviyeniz yükseldi ama sosyalliğiniz azaldı.");
        }

        public void Sleep(Player player)
        {
            UpdatePlayerStats(player,
                energy: 100,     // Enerji maksimuma çıkar
                intelligence: 0,
                social: 0,
                health: 30);     // Sağlık artar

            System.Console.WriteLine("Güzel bir uyku çektiniz. Enerji seviyeniz tamamen yenilendi!");
        }
    }
}
