using System.Xml.Linq;

namespace CampusLifeRPG.Locations
{
    public class Classroom : BaseLocation
    {
        public Classroom()
        {
            Name = "Sınıf";
        }

        public override void Visit(Player player)
        {
            UpdatePlayerStats(player,
                energy: -30,     // Enerji azalır
                intelligence: 70, // Akademik başarı artar
                social: 30,      // Sosyallik artar
                health: -20);    // Sağlık azalır

            System.Console.WriteLine("Dersi dikkatle dinlediniz. Akademik başarınız ve sosyalliğiniz arttı, ama biraz yoruldunuz.");
        }
    }
}
