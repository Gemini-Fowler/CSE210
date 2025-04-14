using System;

namespace EternalQuestApp
{
    public static class LevelManager
    {
        public static string GetLevelName(int score)
        {
            if (score < 100) return "Starry Initiate";
            else if (score < 250) return "Moonlit Seeker";
            else if (score < 500) return "Solar Disciple";
            else if (score < 1000) return "Galactic Wanderer";
            else if (score < 2000) return "Celestial Sage";
            else if (score < 3500) return "Astral Champion";
            else if (score < 5000) return "Ethereal Master";
            else return "Stellar Guardian";
        }
    }
}
