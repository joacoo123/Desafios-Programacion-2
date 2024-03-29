using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/PerfilJugador")]

public class PerfilJugador : ScriptableObject
{
    [SerializeField]
    private int CurrentLevel = 0;
    public int currentLevel { get => CurrentLevel; set => CurrentLevel = value; }
    [Header("Configuracion nivel")]
    [SerializeField]
    private int CurrentExperience = 0;
    public int currentExperience { get => CurrentExperience; set => CurrentExperience = value; }

    [SerializeField]
    private int ExperienceToNextLevel = 20;
    public int experienceToNextLevel { get => ExperienceToNextLevel; set => ExperienceToNextLevel = value; }


    [Header("Configuracion movimiento")]
    [SerializeField]
    private float FuerzaSalto;
    public float fuerzaSalto { get => FuerzaSalto; set => FuerzaSalto = value; }

    [SerializeField]
    private float VelocidadDeMovimiento = 5f;
    public float velocidad { get => VelocidadDeMovimiento; set => VelocidadDeMovimiento = value; }

    [Header("Configuracion de atributos")]
    [SerializeField]
    private int Vida = 5;
    public int vida { get => Vida; set => Vida = value; }

    [Header("Configuracion de SFX")]
    [SerializeField] 
    private bool SonidoSalto;
    public bool sonidoSalto { get => SonidoSalto; set => SonidoSalto = value;}

    [SerializeField] 
    private AudioClip JumpAud;
    public AudioClip jumpAud { get => JumpAud; set => JumpAud = value; }
    
    [SerializeField] 
    private AudioClip JumpAud2;
    public AudioClip jumpAud2 { get => JumpAud2; set => JumpAud2 = value; }
  
}
