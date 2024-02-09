using PojectScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public static class AchievementManager
    {
        public static void CheckAchievements()
        {
            var main = new Game();
            
            if (main.currentScore >= 1000)
            {
                main.achievementScore = true;
            }

            if (main.amount2 >= 2)
            {
                main.achievementShope = true;
            }
            main.image1.color = main.achievementScore ? new Color(0f, 1f, 0f, 1f) : new Color(1f, 1f, 1f, 1f);

            main.image2.color = main.achievementShope ? new Color(0f, 1f, 0f, 1f) : new Color(1f, 1f, 1f, 1f);

        }
    }
}