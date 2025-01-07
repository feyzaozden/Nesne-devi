namespace CampusLifeRPG.Locations
{
    public class RecreationArea : BaseLocation
    {
        public RecreationArea()
        {
            Name = "Dinlenme Alanı";
        }

        public override void Visit(Player player)
        {
            UpdatePlayerStats(player,
                energy: -30,    // Enerji biraz azalır
                intelligence: 0,
                social: 40,     // Sosyallik çok artar
                health: 10);    // Sağlık biraz artar

            System.Console.WriteLine("Dinlenme alanında arkadaşlarınızla keyifli vakit geçirdiniz. Sosyalliğiniz arttı.");
        }
    }
}
