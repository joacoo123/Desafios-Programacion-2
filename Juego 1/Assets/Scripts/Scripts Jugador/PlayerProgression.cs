using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    public int currentLevel;
    public int currentExperience;
    public int experienceToNextLevel;

    public void GainExperience(int experience)
    {
        currentExperience += experience;

        if (currentExperience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        currentExperience -= experienceToNextLevel;
        experienceToNextLevel += 20; // Aumenta la experiencia necesaria para el siguiente nivel

       
    }
}
