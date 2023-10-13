using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    [SerializeField] private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    public void GainExperience(int experience)
    {
        perfilJugador.currentExperience += experience;

        if (perfilJugador.currentExperience >= perfilJugador.experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        perfilJugador.currentLevel++;
        perfilJugador.currentExperience -= perfilJugador.experienceToNextLevel;
        perfilJugador.experienceToNextLevel += 20; // Aumenta la experiencia necesaria para el siguiente nivel

       
    }
}
