using UnityEngine;

public class PlayerProgression : MonoBehaviour
{

    private Jugador misDatos;

    private void OnEnable()
    {
        misDatos = GetComponent<Jugador>();
    }

    public void GainExperience(int experience)
    {
        misDatos.perfilJugador.currentExperience += experience;

        if (misDatos.perfilJugador.currentExperience >= misDatos.perfilJugador.experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        misDatos.perfilJugador.currentLevel++;
        misDatos.perfilJugador.currentExperience -= misDatos.perfilJugador.experienceToNextLevel;
        misDatos.perfilJugador.experienceToNextLevel += 20; // Aumenta la experiencia necesaria para el siguiente nivel

       
    }
}
