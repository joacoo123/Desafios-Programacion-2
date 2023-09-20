using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;

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
    private void Perder(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemigo")) { return;  }
        Debug.Log("Perdiste");
    }


}
