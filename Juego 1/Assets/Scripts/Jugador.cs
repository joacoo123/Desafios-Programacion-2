using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;
    private Rigidbody2D miRigidBody2D;
    private Vector2 initialPosition;

    private void OnEnable()
    {
        miRigidBody2D = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        
    }
    public void  ModificarVida(float puntos)
    {
        if (vida != 0)
        {
            vida += puntos;
            Debug.Log(" VIDA RESTANTE:  " + vida);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }
        Debug.Log("GANASTE");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemigo")) { return;  }
        if(vida<=0) { 
        transform.position = initialPosition;
        Debug.Log("Perdiste");
            vida += 50;
        }
    }


}
