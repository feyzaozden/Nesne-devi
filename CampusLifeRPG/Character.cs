using System;

namespace CampusLifeRPG
{
    public abstract class Character
    {
        protected string Name { get; set; }

        protected Character(string name)
        {
            Name = name;
        }

        public abstract void DisplayStatus();
    }

    public class CampusLifeCharacter : Character
    {
        protected double health;
        protected double energy;
        protected double hunger;
        protected double happiness;
        protected double academicSuccess;
        protected double socialLevel;

        public double Health { get => health; protected set => health = ClampValue(value); }
        public double Energy { get => energy; protected set => energy = ClampValue(value); }
        public double Hunger { get => hunger; protected set => hunger = ClampValue(value); }
        public double Happiness { get => happiness; protected set => happiness = ClampValue(value); }
        public double AcademicSuccess { get => academicSuccess; protected set => academicSuccess = ClampValue(value); }
        public double SocialLevel { get => socialLevel; protected set => socialLevel = ClampValue(value); }

        public CampusLifeCharacter(string name) : base(name)
        {
            ResetStats();
        }

        public virtual void ResetStats()
        {
            Health = 100;
            Energy = 100;
            Hunger = 0;
            Happiness = 100;
            AcademicSuccess = 0;
            SocialLevel = 0;
        }

        public virtual void UpdateStats(double healthDelta, double energyDelta, double hungerDelta, double happinessDelta, double academicDelta, double socialDelta)
        {
            Health = ClampValue(Health + healthDelta);
            Energy = ClampValue(Energy + energyDelta);
            Hunger = ClampValue(Hunger + hungerDelta);
            Happiness = ClampValue(Happiness + happinessDelta);
            AcademicSuccess = ClampValue(AcademicSuccess + academicDelta);
            SocialLevel = ClampValue(SocialLevel + socialDelta);
        }

        protected double ClampValue(double value)
        {
            if (value < 0) return 0;
            if (value > 100) return 100;
            return value;
        }

        public override void DisplayStatus()
        {
            Console.WriteLine($"\n=== {Name}'nin Durumu ===");
            Console.WriteLine($"Sağlık: {Health:F1}%");
            Console.WriteLine($"Enerji: {Energy:F1}%");
            Console.WriteLine($"Açlık: {Hunger:F1}%");
            Console.WriteLine($"Mutluluk: {Happiness:F1}%");
            Console.WriteLine($"Akademik Başarı: {AcademicSuccess:F1}%");
            Console.WriteLine($"Sosyal Seviye: {SocialLevel:F1}%");
        }
    }
}
