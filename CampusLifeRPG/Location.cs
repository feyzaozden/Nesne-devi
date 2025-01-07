namespace CampusLifeRPG
{
    public enum Location
    {
        EmptySpace,
        Dormitory,
        Classroom,
        Library,
        Cafeteria,
        Gym,
        RecreationArea
    }

    public static class LocationExtensions
    {
        public static string GetDescription(this Location location)
        {
            switch (location)
            {
                case Location.EmptySpace:
                    return "Empty Space (passage)";
                case Location.Dormitory:
                    return "Dormitory (rest and sleep)";
                case Location.Classroom:
                    return "Classroom (attend lectures)";
                case Location.Library:
                    return "Library (study)";
                case Location.Cafeteria:
                    return "Cafeteria (eat and socialize)";
                case Location.Gym:
                    return "Gym (exercise)";
                case Location.RecreationArea:
                    return "Recreation Area (socialize and relax)";
                default:
                    return "Unknown location";
            }
        }
    }
}
