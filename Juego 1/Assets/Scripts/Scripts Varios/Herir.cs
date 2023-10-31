using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int puntos = 1;
    [SerializeField] bool isEnemy;
    private EnemyState enemyState;

    private void OnEnable()
    {
        enemyState = GetComponent<EnemyState>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Plataformas"))
        {
          
            if (isEnemy)
            {
                if (enemyState.isAngry)
                {
                   
                    puntos = 2;
                }
                else
                {
                    puntos = 1;
                }
            }
            
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            if (collision.gameObject.CompareTag("Player"))
            {
                jugador.ModificarVida(-puntos);
                Debug.Log(" PUNTOS DE DA�O REALIZADOS AL JUGADOR " + puntos);
            }
            if (!isEnemy)
            {
                gameObject.SetActive(false);
            }
            
        }
    }
}