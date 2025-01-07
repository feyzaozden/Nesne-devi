using System;

namespace CampusLifeRPG
{
    public enum DayTime
    {
        Morning,
        Afternoon,
        Evening
    }

    public class TimeManager
    {
        public DayTime CurrentTime { get; private set; }

        public TimeManager()
        {
            CurrentTime = DayTime.Morning;
        }

        public void AdvanceTime()
        {
            switch (CurrentTime)
            {
                case DayTime.Morning:
                    CurrentTime = DayTime.Afternoon;
                    break;
                case DayTime.Afternoon:
                    CurrentTime = DayTime.Evening;
                    break;
                case DayTime.Evening:
                    CurrentTime = DayTime.Morning;
                    break;
                default:
                    throw new InvalidOperationException("Invalid time state");
            }
        }

        public bool IsEvening()
        {
            return CurrentTime == DayTime.Evening;
        }

        public void ResetDay()
        {
            CurrentTime = DayTime.Morning;
        }
    }
}
