using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador" , menuName = "SO/PerfilJugador")]

public class PerfilJugador : ScriptableObject
{
    [SerializeField]
    private int CurrentLevel;
    public int currentLevel { get => CurrentLevel; set => CurrentLevel = value; }

    [SerializeField]
    private int CurrentExperience;
    public int currentExperience { get => CurrentExperience; set => CurrentExperience = value; }

    [SerializeField]
    private int ExperienceToNextLevel;
    public int experienceToNextLevel { get => ExperienceToNextLevel; set => ExperienceToNextLevel = value; }
}
