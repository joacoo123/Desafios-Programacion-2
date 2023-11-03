using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [SerializeField] public PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    private Rigidbody2D miRigidBody2D;
    private Vector2 initialPosition;
    private int coleccionable;
    private bool reinicio;


    //Eventos---------------
    [SerializeField]
    private UnityEvent<int> OnLivesChanged;

    private void Start()
    {
        OnLivesChanged.Invoke(perfilJugador.vida);
    }
    private void OnEnable()
    {
        miRigidBody2D = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        coleccionable = 0;
        reinicio = false;
    }
    void Update()
    {
        if (reinicio)
        {
            OnLivesChanged.Invoke(perfilJugador.vida);
            reinicio = false;
        }
    }
   
    public void  ModificarVida(int puntos)
    {
        if (perfilJugador.vida != 0)
        {
            perfilJugador.vida += puntos;
            
            Debug.Log(" VIDA RESTANTE:  " + perfilJugador.vida);
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
       
                Debug.Log("GANASTE"); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((!collision.gameObject.CompareTag("Enemigo"))&&(!collision.gameObject.CompareTag("Proyectil"))) { return;  }
        
        if (perfilJugador.vida<=0) {
            reinicio = true;
            transform.position = initialPosition;
            perfilJugador.vida += 5;
            Debug.Log("Perdiste");
        }
    }
  


}
