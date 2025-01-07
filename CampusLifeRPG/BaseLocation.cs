using System;

namespace CampusLifeRPG.Locations
{
    public abstract class BaseLocation
    {
        public string Name { get; protected set; }
        protected readonly Random random = new Random();

        public abstract void Visit(Player player);

        protected virtual void UpdatePlayerStats(Player player, int energy, int intelligence, int social, int health)
        {
            try
            {
                player.UpdateStats(energy, intelligence, social, health);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error updating player stats at {Name}: {ex.Message}");
            }
        }

        public virtual string GetLocationInfo()
        {
            return $"Şu an buradasınız: {Name}";
        }
    }
}
