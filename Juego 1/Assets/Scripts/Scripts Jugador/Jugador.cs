using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    [SerializeField] public PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    
    private AudioSource audioSource;
    private Vector2 initialPosition;
    private int coleccionable;
    private bool reinicio;
    private bool ganar;
    private float elapsedTime;

    //Eventos---------------
    [SerializeField]
    private UnityEvent<int> OnLivesChanged;

    [SerializeField]
    private UnityEvent<string> OnTextChanged;

   
    private void Start()
    {
        OnLivesChanged.Invoke(perfilJugador.vida);
        
        
        
    }
    private void OnEnable()
    {
        //Atributos iniciales del perfil
        perfilJugador.vida = 5;
        perfilJugador.currentLevel = 0;
        perfilJugador.currentExperience = 0;
        perfilJugador.experienceToNextLevel = 20;
        //---------------------------

        audioSource = GetComponent<AudioSource>();
        initialPosition = transform.position;
        coleccionable = 0;
        elapsedTime = 0;
        ganar = false;
        reinicio = false;
        OnTextChanged.Invoke(perfilJugador.currentLevel.ToString());
    }
    void Update()
    {
        
        if (ganar)
        {
            
            audioSource.volume -= 0.0005f;
            Debug.Log("Volumen: "+audioSource.volume);
            elapsedTime += Time.deltaTime;
         
            if (elapsedTime >= 3)
            {
                Debug.Log("pasaron 3");
                SceneManager.LoadScene(2);

            }
        }
        if (reinicio)
        {
            OnLivesChanged.Invoke(perfilJugador.vida);
            reinicio = false;
        }
        OnTextChanged.Invoke(perfilJugador.currentLevel.ToString());
    }
   
    public void  ModificarVida(int puntos)
    {
       
        if (perfilJugador.vida != 0)
        {
            perfilJugador.vida += puntos;
            
            //Debug.Log(" VIDA RESTANTE:  " + perfilJugador.vida);
            GameManager.Instance.getPlayerLives(perfilJugador.vida);
        }
        OnLivesChanged.Invoke(perfilJugador.vida);

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coleccionable")) {
            coleccionable += 1;
            Debug.Log("Coleccionables: " + coleccionable);
            
        }

        if (!collision.gameObject.CompareTag("Meta")||(coleccionable != 3)) { return; }


        ganar = true;
                Debug.Log("GANASTE"); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((!collision.gameObject.CompareTag("Enemigo"))&&(!collision.gameObject.CompareTag("Proyectil"))) { return;  }
        
        if (perfilJugador.vida<=0) {
            reinicio = true;
            //transform.position = initialPosition;
            //perfilJugador.vida += 5;
            //Debug.Log("Perdiste");
        }
    }
  


}
